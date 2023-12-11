using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Data class that returns a page of data records from a <see cref="PagingRequest"/>.
    /// </summary>
    /// <typeparam name="T">Type of the data records to be returned.</typeparam>
    public class PageResponse<T> where T : class
    {

        /// <summary>
        /// The total number of records that are available in the entire set.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// The page data result from the request.
        /// </summary>
        public List<T> Result { get; set; } = new List<T>();

    }
}
