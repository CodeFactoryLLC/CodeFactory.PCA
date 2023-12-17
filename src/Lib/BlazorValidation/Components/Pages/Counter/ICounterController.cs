using CodeFactory.PCA.Blazor;

namespace BlazorValidation.Components.Pages.Counter
{
    public interface ICounterController:IController
    {
        /// <summary>
        /// Save the counter value to the database.
        /// </summary>
        /// <param name="counterValue">Value to be saved.</param>
        /// <returns>True if saved, false if error occurred.</returns>
        public Task<bool> SaveCounterValueAsync(int counterValue);
    }
}
