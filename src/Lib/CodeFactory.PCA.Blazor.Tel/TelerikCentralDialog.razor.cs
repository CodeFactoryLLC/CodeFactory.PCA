using Microsoft.AspNetCore.Components;
using Telerik.Blazor;

namespace CodeFactory.PCA.Blazor.Tel
{
    public partial class TelerikCentralDialog
    {

        [CascadingParameter]
        public DialogFactory Dialogs { get; set; }


        /// <summary>
        /// Shows an alert dialog box. 
        /// </summary>
        /// <param name="message">The message to display in the alert dialog.</param>
        /// <param name="title">The title to assign to the alert dialog box.</param>
        /// <param name="buttonTitle">The title to assign to the button on the alert.</param>
        public override async Task RaiseAlertAsync(string message, string title, string buttonTitle)
        { 
           await (Dialogs?.AlertAsync(message, title, buttonTitle) ?? Task.CompletedTask);
        }

        /// <summary>
        /// Shows a confirmation dialog box. 
        /// </summary>
        /// <param name="message">The message to display in the confirmation dialog.</param>
        /// <param name="title">The title to assign to the confirmation dialog box.</param>
        /// <param name="buttonNoTitle">The title to assign to the no button on the confirmation.</param>
        /// <param name="buttonYesTitle">The title to assign to the Yes button on the confirmation.</param>
        /// <returns>The confirmation decision made by the user.</returns>
        public override async Task<bool> RaiseConfirmationAsync(string message, string title, string buttonNoTitle = "No", string buttonYesTitle = "Yes")
        { 
        
            var result = await (Dialogs?.ConfirmAsync(message,title,buttonYesTitle,buttonNoTitle) ?? Task<bool>.FromResult(false));
            return result;
        }


    }
}
