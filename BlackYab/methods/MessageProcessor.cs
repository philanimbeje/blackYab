using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackYab
{
   public class MessageProcessor
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

        public string ProcessorMessage(string message)
        {
            var splitMessage = new string[7];
            splitMessage = Convert.ToString(message).Split('/');

            var compiledMessage = "";

            foreach (string word in splitMessage)
            {
                compiledMessage += word + "-";
            }

            splitMessage = Convert.ToString(compiledMessage).Split(':');

            var compiledMessage2 = "";

            foreach (string word in splitMessage)
            {
                compiledMessage2 += word + "_";
            }
            return compiledMessage2;
        }
    }
}
