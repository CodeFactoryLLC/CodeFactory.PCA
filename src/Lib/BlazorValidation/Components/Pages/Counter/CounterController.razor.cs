using CodeFactory.PCA.Blazor;
using Microsoft.Extensions.Logging;

namespace BlazorValidation.Components.Pages.Counter
{
    public partial class CounterController : ICounterController
    {


        public Task<bool> SaveCounterValueAsync(int counterValue)
        {
            return Task.FromResult(true);
        }

    }
}
