using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using CodeFactory.PCA.Blazor;

namespace BlazorValidation.Components.Template
{
    /// <summary>
    /// Logic implementation for the controller 'Presentation'
    /// </summary>
    public partial class PresentationController : IPresentationController
    {
        #region Logging

        /// <summary>
        /// Logger instance for the controller.
        /// </summary>
        [Inject]
        private ILogger<PresentationController> Logger { get; set; }

        /// <summary>
        /// Field definition of the logger used for logging messages in the controller. 
        /// </summary>
        private ILogger _logger;

        #endregion

        /// <summary>
        /// The model that is supported by the controller.
        /// </summary>
        public PresentationModel Model { get; set; } = new PresentationModel();

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
