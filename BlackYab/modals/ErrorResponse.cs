using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
    class ErrorResponse
    {
        #region Properties
        public bool canAccess { get; set; }
        public string ErrorMessage { get; set; }
        public WordList Error_Message { get; set; }
        #endregion

        #region constructors
        public ErrorResponse()
        {
            this.canAccess = false;
            this.ErrorMessage = "undescribed error detected";
        }

        public ErrorResponse(bool access, WordList message)
        {
            this.canAccess = access;

            var splitMessage = new string[7];
            splitMessage= Convert.ToString(message).Split('_');

            var compiledMessage = "";

            foreach(string word in splitMessage)
            {
                compiledMessage += word + " "; 
            }

            this.ErrorMessage = compiledMessage;
        }

        public ErrorResponse(bool access)
        {
            this.canAccess = access;
            this.ErrorMessage = access ? "login successful" : "undescribed error detected";
        }
        #endregion
    }
}
