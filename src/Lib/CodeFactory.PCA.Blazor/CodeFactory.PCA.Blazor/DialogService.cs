
namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Service that provides access to the central component that displays dialog messages.
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>
        /// Creates an instance of the <see cref="DialogService"/>
        /// </summary>
        public DialogService() 
        { 
            //Intentionally blank
        }

        private IDialogSubmission _dialogSubmission = null;

        public async Task RaiseAlertAsync(string message, string title, string buttonTitle)
        {
            await (_dialogSubmission?.RaiseAlertAsync(message, title, buttonTitle) ?? Task.CompletedTask);
        }

        public async Task<bool> RaiseConfirmationAsync(string message, string title, string buttonNoTitle = "No", string buttonYesTitle = "Yes")
        {
            var result = await (_dialogSubmission?.RaiseConfirmationAsync(message,buttonNoTitle,buttonYesTitle) ?? Task.FromResult<bool>(false));

            return result;
        }

        public void RegisterDialogProvider(CentralDialogComponentBase provider)
        {
            _dialogSubmission = provider;
        }
    }
}
