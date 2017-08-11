using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
    class ErrorResponse
    {
        MessageProcessor Message = new MessageProcessor();
        #region Properties
        public bool canAccess { get; set; }
        public string ErrorMessage { get; set; }
        public WordList Error_Message { get; set; }
        #endregion

        #region constructors
        public ErrorResponse(WordList message)
        {
            this.canAccess = false;
            this.ErrorMessage = Message.ProcessorMessage(message);
        }

        public ErrorResponse()
        {
            this.canAccess = false;
            this.ErrorMessage = Message.ProcessorMessage(WordList.Undescribed_error_detected);
        }

        public ErrorResponse(bool access, WordList message)
        {
            this.canAccess = access;
            this.ErrorMessage = Message.ProcessorMessage(message);
        }

        public ErrorResponse(bool access)
        {
            this.canAccess = access;
            this.ErrorMessage = access ? Message.ProcessorMessage(WordList.Login_successful): Message.ProcessorMessage(WordList.Undescribed_error_detected);
        }
        #endregion
    }
}
