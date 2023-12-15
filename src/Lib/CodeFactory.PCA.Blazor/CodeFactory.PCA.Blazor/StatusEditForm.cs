using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CodeFactory.PCA.Blazor
{
    public class StatusEditForm:EditForm,IAsyncDisposable
    {

        private bool _isModified = false;

        /// <summary>
        /// Supplies the edit context explicitly. If using this parameter, do not
        /// also supply <see cref="Model"/>, since the model value will be taken
        /// from the <see cref="EditContext.Model"/> property.
        /// </summary>
        [Parameter]
        public new EditContext? EditContext 
        {
            get 
            {
                return base.EditContext;
            }
            set
            {
                ReleaseSubscriptionToEditContext(base.EditContext);
                base.EditContext = value;
                SubscribeToEditContext(base.EditContext);
            }
        }

        /// <summary>
        /// Specifies the top-level model object for the form. An edit context will
        /// be constructed for this model. If using this parameter, do not also supply
        /// a value for <see cref="EditContext"/>.
        /// </summary>
        [Parameter]
        public new object? Model
        {
            get
            {
                return base.EditContext?.Model;
            }

            set
            {
                if (value == null) throw new InvalidOperationException("The 'Model' cannot be null, it must be an instance with data.");

                if (base.EditContext?.Model != value)
                {
                    var context = new EditContext(value);
                    EditContext = context;

                }
            }
        }

        [Parameter]
        public EventCallback<bool> DataStatusChanged { get; set; }


        private void SubscribeToEditContext(EditContext? editContext)
        {
            if(editContext !=null) editContext.OnFieldChanged += EditContext_OnFieldChanged;
        }

        private void ReleaseSubscriptionToEditContext(EditContext? editContext)
        {
            if(editContext != null) editContext.OnFieldChanged -= EditContext_OnFieldChanged;
        }

        private async void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
        {
            var context = base.EditContext;

            if(context != null) 
            {
                var isModified =  context.IsModified();

                if (isModified != _isModified)
                {
                    if (DataStatusChanged.HasDelegate)
                    { 
                        _isModified = isModified;

                       await DataStatusChanged.InvokeAsync(_isModified);
                    }
                }
            }
        }

        public ValueTask DisposeAsync()
        {
            ReleaseSubscriptionToEditContext(base.EditContext);

            return ValueTask.CompletedTask;
        }


        public void SetDataUnmodified()
        {
            base.EditContext?.MarkAsUnmodified();
        }
    }
}
