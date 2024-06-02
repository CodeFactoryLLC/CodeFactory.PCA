using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Data class that provides information to retrieve a target page size of data.
    /// </summary>
    public class PagingDataRequest<SC>: DataRequest<SC> where SC : class
    {
        /// <summary>
        /// The page to be returned. Default is set to 1.
        /// </summary>
        public int Page { get; set; } = 1;

    }
}
