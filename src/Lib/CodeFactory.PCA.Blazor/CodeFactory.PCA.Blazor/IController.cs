namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Contract definition for the controller contracts.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Determines if the controller should prompt before navigation changes are allowed to complete.
        /// </summary>
        /// <param name="promptForNavigationChange">Flag that determines if the navigation should be prompted before executing.</param>
        /// <param name="promptMessage">Optional parameter, sets the message to be displayed when prompting to leave.</param>
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        Task PromptForNavigationChangeAsync(bool promptForNavigationChange, string promptMessage = null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
    }
}
