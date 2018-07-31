using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialChat.Common.DTO;

namespace FinancialChat.Store.Classes
{
    public class Users
    {
        public Users()
        {
            this.users = new List<UserRecord>();
        }

        public List<UserRecord> users;
    }
}
