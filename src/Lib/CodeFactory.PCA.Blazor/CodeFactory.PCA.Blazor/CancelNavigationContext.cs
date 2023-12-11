using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFactory.PCA.Blazor
{
    /// <summary>
    /// Data class that determines if navigation should be cancelled.
    /// </summary>
    public class CancelNavigationContext
    {
        /// <summary>
        /// Flag that determines if navigation should be cancelled. Default is null.
        /// </summary>
        public bool Cancel { get; set; } = false;
    }
}
