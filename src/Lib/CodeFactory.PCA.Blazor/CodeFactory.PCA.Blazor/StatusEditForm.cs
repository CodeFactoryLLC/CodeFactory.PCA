using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Extended version of <see cref="EditForm"/> that provides notification when data has been modified on the form. 
    /// </summary>
    public class StatusEditForm:EditForm,IAsyncDisposable
    {
        /// <summary>
        /// Flag that tracks if any of the field in the edit form have been modified. 
        /// </summary>
        private bool _isModified = false;

        /// <summary>
        /// Tracks the edit context on the form. 
        /// </summary>
        private EditContext? _currentEditContext;

        /// <summary>
        /// Stores the list of fields that have been modified. 
        /// </summary>
        private List<string> _modifiedFields = new List<string>();
        
        [Parameter]
        public EventCallback<EditFormDataStatus> DataModifiedStatusChanged { get; set; }

        /// <summary>
        /// Status flag that provides the current status of the form data. 
        /// </summary>
        public bool IsFormDataModified => _isModified;  

        /// <summary>
        /// List of the fields that have been modified by the edit form. 
        /// </summary>
        public List<string> ModifiedFields => _modifiedFields;


        /// <inheritdoc/>
        protected override Task OnInitializedAsync()
        {
            base.OnInitializedAsync();
            _currentEditContext = base.EditContext;

            return Task.CompletedTask;
        }

        /// <inheritdoc/>
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if(_currentEditContext != base.EditContext ) 
            {
                await ReleaseSubscriptionToEditContextAsync(_currentEditContext);
                _currentEditContext = base.EditContext;
                await SubscribeToEditContextAsync(base.EditContext);
            }


        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            await ReleaseSubscriptionToEditContextAsync(base.EditContext);
            _currentEditContext = null;
            _modifiedFields = null;
        }

        /// <summary>
        /// Updates the active edit context in the form to reset all the field to be unmodified. 
        /// </summary>
        public async Task SetDataUnmodifiedAsync()
        {
            base.EditContext?.MarkAsUnmodified();

            var modified = _isModified;

            SetIsModified(false);

            if (modified != _isModified) await OnDataModifiedStatusChange(_isModified);

           
        }

        /// <summary>
        /// Sets the value of the _isModified field and resets the _modifiedFields list if is modified is false.
        /// </summary>
        /// <param name="isModified">value for the _isModified field.</param>
        private void SetIsModified(bool isModified ) 
        {
            _isModified = isModified;

            if (!_isModified) _modifiedFields = new List<string>();
        }

        /// <summary>
        /// Subscribes to the <see cref="EditContext.OnFieldChanged"/> event on the current <see cref="EditContext"/>
        /// </summary>
        /// <param name="editContext">the current version of edit context to subscribe to.</param>
        private async Task SubscribeToEditContextAsync(EditContext? editContext)
        {
            //Internal clean up of tracking members.
            _modifiedFields = new List<string>();

            if (_isModified)
            {
                SetIsModified(false);
                await OnDataModifiedStatusChange(_isModified);
            }

            if (editContext != null)
            {
                editContext.OnFieldChanged += EditContext_OnFieldChanged;
            }

        }

        /// <summary>
        /// Releases the subscription to the event <see cref="EditContext.OnFieldChanged"/> from the current <see cref="EditContext"/>
        /// </summary>
        /// <param name="editContext">The edit context to remove the event registration from.</param>
        private Task ReleaseSubscriptionToEditContextAsync(EditContext? editContext)
        {
            if (editContext != null) editContext.OnFieldChanged -= EditContext_OnFieldChanged;

            return Task.CompletedTask;
        }

        /// <summary>
        /// Event handler for the <see cref="EditContext.OnFieldChanged"/> event.
        /// </summary>
        /// <param name="sender">Edit context the event was raised from.</param>
        /// <param name="e">The status of the field change.</param>
        private async void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            var context = base.EditContext;

            if (context != null)
            {
                if (context.IsModified(e.FieldIdentifier))
                {
                    if (!_modifiedFields.Contains(e.FieldIdentifier.FieldName)) _modifiedFields.Add(e.FieldIdentifier.FieldName);
                }
                else
                {
                    _modifiedFields.Remove(e.FieldIdentifier.FieldName);
                }
                var isModified = context.IsModified();

                if (isModified != _isModified)
                {
                    SetIsModified(isModified);

                    await OnDataModifiedStatusChange(_isModified);
                }
            }
        }

        /// <summary>
        /// Rases the <see cref="DataModifiedStatusChanged"/> parameter handler if subscriber to.
        /// </summary>
        /// <param name="isModified">Flag that determines if any field has been modified on the edit form.</param>
        private async Task OnDataModifiedStatusChange(bool isModified)
        {
            if (DataModifiedStatusChanged.HasDelegate) await DataModifiedStatusChanged.InvokeAsync(new EditFormDataStatus { IsModified = isModified });
        }
    }
}
