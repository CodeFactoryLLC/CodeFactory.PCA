using CodeFactory.PCA.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BlazorValidation.Components.Test
{
    /// <summary>
    /// Logic implementation for the presentation 'Test'
    /// </summary>
    public partial class Test
    {

        #region Logging

        /// <summary>
        /// Logger instance for the presentation.
        /// </summary>
        [Inject]
        private ILogger<Test> Logger { get; set; }

        /// <summary>
        /// Field definition of the logger used for logging messages in the presentation. 
        /// </summary>
        private ILogger _logger;

        #endregion

        /// <summary>
        /// Controller that supports this presentation.
        /// </summary> 
        private ITestController Controller { get; set; }

        /// <inheritdoc/>
        protected override void InitializePresentation()
        {
            try
            {
                //Setting the field reference to the logger.
                _logger = Logger;
            }
            finally
            {
                base.InitializePresentation();
            }
        }
    }
}
