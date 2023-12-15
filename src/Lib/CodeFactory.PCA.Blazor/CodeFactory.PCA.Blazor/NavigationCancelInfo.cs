namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Data class that tracks if a navigation event should be cancelled. 
    /// </summary>
    public class NavigationCancelInfo
    {

        /// <summary>
        /// Flag that determines if a navigation location change should be cancelled or not.
        /// </summary>
        public bool CancelNavigationChange { get; set; } = false;

        /// <summary>
        /// Message to be displayed to the user when prompting to cancel navigation
        /// </summary>
        public string PromptMessage { get; set; }
    }
}
