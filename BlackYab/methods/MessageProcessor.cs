using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
    class MessageProcessor
    {
        public string ProcessorMessage(WordList message)
        {
            var splitMessage = new string[7];
            splitMessage = Convert.ToString(message).Split('_');

            var compiledMessage = "";

            foreach (string word in splitMessage)
            {
                compiledMessage += word + " ";
            }
            return compiledMessage;
        }
    }
}
