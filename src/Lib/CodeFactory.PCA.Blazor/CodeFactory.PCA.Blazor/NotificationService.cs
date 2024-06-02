
namespace CodeFactory.PCA.Blazor
{
    public class NotificationService : INotificationService
    {
        public NotificationService() 
        {
            //Intentionally blank
        }

        private INotificationSubmission _notificationComponent = null;

        public async Task ErrorNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.ErrorNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        public async Task InformationNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.InformationNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        public void RegisterNotificationProvider(CentralNotificationComponentBase provider)
        {
            _notificationComponent = provider;
        }

        public async Task SuccessNotificationAsync(string message, int timeout = 5000)
        {
            await (_notificationComponent?.SuccessNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }

        public async Task WarningNotificationAsync(string message, int timeout = 5000)
        {
            await(_notificationComponent?.WarningNotificationAsync(message, timeout) ?? Task.CompletedTask);
        }
    }
}
