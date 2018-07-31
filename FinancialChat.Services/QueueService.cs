using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Services
{
    public class QueueService
    {
        private static List<string> BotMessages =  new List<string>();

        public static string getMessage()
        {
            if(BotMessages.Count > 0)
            {
                var message = BotMessages[0].ToString();
                BotMessages.RemoveAt(0);
                return message;
            }

            return "";
        }

        public static void setMessage(string botMessage)
        {
            if(botMessage[0] != '/')
            {
                BotMessages.Add(botMessage);
            }
        }
    }
}
