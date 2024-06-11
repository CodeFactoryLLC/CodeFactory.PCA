
namespace CodeFactory.PCA.Blazor
{
    public class NotificationService : INotificationService
    {
        public NotificationService() 
        {
            //Intentionally blank
        }

        private INotificationSubmission _notificationComponent = null;

        ///<inheritdoc/>
        public async Task ErrorNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.ErrorNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        ///<inheritdoc/>
        public async Task InformationNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.InformationNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        ///<inheritdoc/>
        public void RegisterNotificationProvider(CentralNotificationComponentBase provider)
        {
            _notificationComponent = provider;
        }

        ///<inheritdoc/>
        public async Task SuccessNotificationAsync(string message, int timeout = 5000)
        {
            await (_notificationComponent?.SuccessNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        ///<inheritdoc/>
        public async Task WarningNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.WarningNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }
    }
}
