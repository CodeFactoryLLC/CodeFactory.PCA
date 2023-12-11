using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Data class that provides the sort direction for a field.
    /// </summary>
    public class FieldSort
    {
        /// <summary>
        /// Name of the field to be sorted.
        /// </summary>
        public string FieldName { get; set; }

        /// <summary>
        /// Flag that determines if the field is in descending or ascending order.
        /// </summary>
        public bool IsDescending { get; set; }
    }
}
