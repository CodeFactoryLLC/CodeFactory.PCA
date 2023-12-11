using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFactory.PCA.Models
{
    /// <summary>
    /// Data class that provides the information to be displayed in a dialog from the controller.
    /// </summary>
    public class ControllerDialogMessage:ControllerMessage
    {
        /// <summary>
        /// The title of the dialog. 
        /// </summary>
        public string Title { get; set; }

    }
}
