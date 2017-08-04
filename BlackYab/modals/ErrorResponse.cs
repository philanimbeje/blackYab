using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
    class ErrorResponse
    {
        public bool AccessBool { get; set; }
        public string ErrorMessage { get; set; }

        public ErrorResponse()
        {
            this.AccessBool = false;
            this.ErrorMessage = "No arguments recieved";
        }

        public ErrorResponse(bool access, string message)
        {
            this.AccessBool = access;
            this.ErrorMessage = message;
        }

        public ErrorResponse(bool access)
        {
            if (access==true)
            {
                this.AccessBool = access;
                this.ErrorMessage = "login successful";
            }
            if (access==false)
            {
                this.AccessBool = access;
                this.ErrorMessage = "undescribed error detected";
            }
            
        }
    }
}
