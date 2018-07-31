using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialChat.Common.DTO;

namespace FinancialChat.Store.Classes
{
    public class Chat
    {
        public List<Message> messages;

        public Chat()
        {
            this.messages = new List<Message>();
        }
    }
}
