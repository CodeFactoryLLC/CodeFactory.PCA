using Microsoft.AspNetCore.Components;

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Base component implementation to be used for central dialog based components. 
    /// </summary>
    public abstract class CentralDialogComponentBase : ComponentBase, IDialogSubmission,IAsyncDisposable
    {

        [Inject]
        private IDialogService DialogService { get; set; }

        /// <summary>
        /// Shows an alert dialog box. 
        /// </summary>
        /// <param name="message">The message to display in the alert dialog.</param>
        /// <param name="title">The title to assign to the alert dialog box.</param>
        /// <param name="buttonTitle">The title to assign to the button on the alert.</param>
        public abstract Task RaiseAlertAsync(string message, string title, string buttonTitle);

        /// <summary>
        /// Shows a confirmation dialog box. 
        /// </summary>
        /// <param name="message">The message to display in the confirmation dialog.</param>
        /// <param name="title">The title to assign to the confirmation dialog box.</param>
        /// <param name="buttonNoTitle">The title to assign to the no button on the confirmation.</param>
        /// <param name="buttonYesTitle">The title to assign to the Yes button on the confirmation.</param>
        /// <returns>The confirmation decision made by the user.</returns>
        public abstract Task<bool> RaiseConfirmationAsync(string message, string title, string buttonNoTitle = "No", string buttonYesTitle = "Yes");

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                DialogService?.RegisterDialogProvider(this);
            }

            return base.OnAfterRenderAsync(firstRender);
        }

        public ValueTask DisposeAsync()
        {

            DialogService?.RegisterDialogProvider(null);
            return ValueTask.CompletedTask;
        }
    }
}
