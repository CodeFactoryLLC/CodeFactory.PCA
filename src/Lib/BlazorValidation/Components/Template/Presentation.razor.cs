using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using CodeFactory.PCA.Blazor;

namespace BlazorValidation.Components.Template
{
    public partial class Presentation
    {
        #region Logging
         
        /// <summary>
        /// Logger instance for the presentation.
        /// </summary>
        [Inject]
        private ILogger<Presentation> Logger { get; set; }

        /// <summary>
        /// Field definition of the logger used for logging messages in the presentation. 
        /// </summary>
        private ILogger _logger;
        
        #endregion

        /// <summary>
        /// Controller that supports this presentation.
        /// </summary>
        private IPresentationController Controller { get; set; }

        /// <summary>
        /// The model that is supported by the controller.
        /// </summary>
        private PresentationModel Model { get; set; } = new PresentationModel();

        /// <inheritdoc/>
        protected override void InitializePresentation()
        {
            try
            {
                //Setting the reference to the presentations model.
                Controller.Model = Model;

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
