using CodeFactory.PCA.Blazor;

namespace BlazorValidation.Components.Pages.Counter
{
    public partial class CounterController : ICounterController
    {
        public Task PromptForNavigationChangeAsync(bool promptForNavigationChange, string promptMessage = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveCounterValueAsync(int counterValue)
        {
            return Task.FromResult(true);
        }

        private void test()
        {

        }
    }
}
