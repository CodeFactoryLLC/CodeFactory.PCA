
namespace CodeFactory.PCA.Blazor
{
    public interface INotificationService:INotificationSubmission
    {
        /// <summary>
        /// Registers the component that will display notification messages.
        /// </summary>
        /// <param name="provider">The notification component that will display notification messages. </param>
        void RegisterNotificationProvider(CentralNotificationComponentBase provider);


    }
}
