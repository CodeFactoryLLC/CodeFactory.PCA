using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Data class that provides information to retrieve a target page size of data.
    /// </summary>
    public class PagingRequest
    {
        /// <summary>
        /// The page to be returned.
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// The number of data records to be retrieved with the request.
        /// </summary>
        public int PageSize { get; set; } = 5;

        /// <summary>
        /// Optional information that provides criteria to be search for when getting the pages information.
        /// </summary>
        public string SearchCriteria { get; set; }

        /// <summary>
        /// Optional list of fields to be sorted when returning the data. The sort priority is based on the order in the list.
        /// </summary>
        public List<FieldSort> SortedFields { get; set; } = new List<FieldSort>();
    }
}
