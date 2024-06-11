using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using CodeFactory.PCA.Blazor;

namespace $rootnamespace$
{
    /// <summary>
    /// Logic implementation for the controller '$safeitemrootname$'
    /// </summary>
    public partial class $safeitemrootname$ : I$safeitemrootname$
    {
        #region Logging

        /// <summary>
        /// Logger instance for the controller.
        /// </summary>
        [Inject]
        private ILogger<$safeitemrootname$> Logger { get; set; }

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
