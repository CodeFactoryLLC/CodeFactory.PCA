using Microsoft.AspNetCore.Components;

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Base component implementation all presentation components should implement. 
    /// </summary>
    public class PresentationComponentBase:ComponentBase
    {
        /// <summary>
        /// Injecting notification service into the controller.
        /// </summary>
        [Inject]
        private INotificationService NotificationService { get; set; }

        /// <summary>
        /// Injecting the dialog service into the controller.
        /// </summary>
        [Inject]
        private IDialogService DialogService { get; set; }

        /// <summary>
        /// Service that allows you to raise a notification to the central notification handler.
        /// </summary>
        protected INotificationSubmission CentralNotification => NotificationService;

        /// <summary>
        /// Service that allows you to raise a dialog to the central dialog handler. 
        /// </summary>
        protected IDialogSubmission CentralDialog => DialogService;

        /// <inheritdoc/>
        protected override void OnAfterRender(bool firstRender)
        {
            try
            {
                if (firstRender) InitializePresentation();
            }
            finally
            {
                base.OnAfterRender(firstRender);
            }

        }

        /// <summary>
        /// Initialization logic for the presentation during the first render of the presentation component.
        /// </summary>
        protected virtual void InitializePresentation()
        {
            //Intentionally blank
        }

        /// <inheritdoc/>
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            try
            {
                if (firstRender) await InitializePresentationAsync();
            }
            finally
            {
                await base.OnAfterRenderAsync(firstRender);
            }

        }

        /// <summary>
        /// Initialization logic for the presentation during the first render of the presentation component.
        /// </summary>
        protected virtual Task InitializePresentationAsync()
        {
            return Task.CompletedTask;
        }

    }
}
