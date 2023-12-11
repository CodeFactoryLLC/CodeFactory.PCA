using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Enumeration that is used to communicate the status of information used in the system.
    /// </summary>
    public enum StatusType
    {
        /// <summary>
        /// The current status is information in nature.
        /// </summary>
        Information = 0,
        
        /// <summary>
        /// The current status means something has completed successfully.
        /// </summary>
        Success = 2,

        /// <summary>
        /// The current status is a warning.
        /// </summary>
        Warning = 3,

        /// <summary>
        /// The current status means an error has occurred. 
        /// </summary>
        Error = 4,
    }
}
