using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    public class DataRequest<SC> where SC : class
    {
        /// <summary>
        /// The number of data records to be retrieved with the request. Default is 5.
        /// </summary>
        public int DataSize { get; set; } = 5;

        /// <summary>
        /// Optional information that provides criteria to be search for when getting the pages information.
        /// </summary>
        public SC SearchCriteria { get; set; }

        /// <summary>
        /// Optional list of fields to be sorted when returning the data. The sort priority is based on the order in the list.
        /// </summary>
        public List<FieldSort> SortedFields { get; set; } = new List<FieldSort>();
    }
}
