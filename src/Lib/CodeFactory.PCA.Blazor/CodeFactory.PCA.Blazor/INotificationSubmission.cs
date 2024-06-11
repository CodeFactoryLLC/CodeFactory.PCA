
namespace CodeFactory.PCA.Blazor
{
    public interface INotificationSubmission
    {
        /// <summary>
        /// Submits an error notification.
        /// </summary>
        /// <param name="message">The error message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        Task ErrorNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an warning notification.
        /// </summary>
        /// <param name="message">The warning message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        Task WarningNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an information notification.
        /// </summary>
        /// <param name="message">The information message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        Task InformationNotificationAsync(string message, int timeout = 5000);

        /// <summary>
        /// Submits an success notification.
        /// </summary>
        /// <param name="message">The success message to display in the notification.</param>
        /// <param name="timeout">How long to display the notification for in milliseconds. Default is 5 seconds or 5000</param>
        Task SuccessNotificationAsync(string message, int timeout = 5000);
    }
}
