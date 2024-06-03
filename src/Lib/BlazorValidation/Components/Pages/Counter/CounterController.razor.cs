using CodeFactory.PCA.Blazor;

namespace BlazorValidation.Components.Pages.Counter
{
    public partial class CounterController : ICounterController
    {


        public Task<bool> SaveCounterValueAsync(int counterValue)
        {
            return Task.FromResult(true);
        }

        private void test()
        {

        }
    }
}
