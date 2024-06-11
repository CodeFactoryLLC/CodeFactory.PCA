using Microsoft.AspNetCore.Components;

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Base component implementation to be used for central notification based components. 
    /// </summary>
    public abstract class CentralNotificationComponentBase : ComponentBase, INotificationSubmission,IAsyncDisposable
    {

        /// <summary>
        /// Submits an error notification.
        /// </summary>
        /// <param name="message">The error message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        public abstract Task ErrorNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an warning notification.
        /// </summary>
        /// <param name="message">The warning message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        public abstract Task WarningNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an information notification.
        /// </summary>
        /// <param name="message">The information message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        public abstract Task InformationNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an success notification.
        /// </summary>
        /// <param name="message">The success message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        public abstract Task SuccessNotificationAsync(string message, int timeout = 5000);

        [Inject]
        private INotificationService NotificationService { get; set; }

        /// <summary>
        /// Overriding the default implementation of OnAfterRenderAsync. Registering the navigation component that display notification messages.  
        /// </summary>
        /// <param name="firstRender">Flag that determines if it is the first render of the component.</param>
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) 
            { 
                NotificationService?.RegisterNotificationProvider(this);
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        /// <summary>
        /// Cleans up component removing references from shared services from dependency injection. 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            NotificationService?.RegisterNotificationProvider(null);
            NotificationService = null;
            return ValueTask.CompletedTask;
        }
    }
}
