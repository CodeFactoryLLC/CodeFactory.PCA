using CodeFactory.PCA.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorValidation.Components.Test
{
    /// <summary>
    /// Logic implementation for the controller 'TestController'
    /// </summary>
    public partial class TestController : ITestController
    {
        #region Logging

        /// <summary>
        /// Logger instance for the controller.
        /// </summary>
        [Inject]
        private ILogger<TestController> Logger { get; set; }

        /// <summary>
        /// Field definition of the logger used for logging messages in the controller. 
        /// </summary>
        private ILogger _logger;

        #endregion

        /// <inheritdoc/>
        protected override void InitializeController()
        {
            try
            {
                //Setting the field reference to the logger.
                _logger = Logger;


            }
            finally
            {
                base.InitializeController();
            }

        }

    }
}
