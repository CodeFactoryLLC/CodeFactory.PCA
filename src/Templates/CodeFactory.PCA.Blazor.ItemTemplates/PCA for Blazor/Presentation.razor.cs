﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using CodeFactory.PCA.Blazor;

namespace $rootnamespace$
{
    /// <summary>
    /// Logic implementation for the presentation '$safeitemrootname$'
    /// </summary>
    public partial class $safeitemrootname$
    {

        #region Logging
        
        /// <summary>
        /// Logger instance for the presentation.
        /// </summary>
        [Inject]
        private ILogger<$safeitemrootname$> Logger { get; set; }

        /// <summary>
        /// Field definition of the logger used for logging messages in the presentation. 
        /// </summary>
        private ILogger _logger;

        #endregion

        /// <summary>
        /// Controller that supports this presentation.
        /// </summary> 
        private I$safeitemrootname$Controller Controller { get; set; }

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
