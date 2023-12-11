using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// A message from the controller to be displayed by the presentation of the system.
    /// </summary>
    public class ControllerMessage
    {
        /// <summary>
        /// The status of the dialog message.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// The message to be displayed in the dialog.
        /// </summary>
        public string Message { get; set; }
    }
}
