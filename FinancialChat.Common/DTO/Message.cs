using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Common.DTO
{
    public class Message
    {
        public string MessageContent { get; set; }
        public DateTime date { get; set; }
        public string Username { get; set; }
    }
}
