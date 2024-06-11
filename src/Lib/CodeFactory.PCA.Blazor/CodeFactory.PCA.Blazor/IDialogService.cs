

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Contract that defines the central service for dialogs. 
    /// </summary>
    public interface IDialogService:IDialogSubmission
    {
        /// <summary>
        /// Registers the component that will display dialogs.
        /// </summary>
        /// <param name="provider">The central dialog component that will display dialogs </param>
        void RegisterDialogProvider(CentralDialogComponentBase provider);
    }
}
