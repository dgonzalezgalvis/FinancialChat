using FinancialChat.Common.DTO;
using FinancialChat.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp1.Common
{
    public class UserValidation
    {
        public static UserRecord CreateUserRecord(string username, string firstname, string lastname, string password)
        {
            var user = new UserRecord();
            user.Username = username;
            user.FirstName = firstname;
            user.LastName = lastname;
            user.Password = password;
            return user;
        }

        public static bool ValidatePassword(UserRecord user, string password)
        {
            if (!String.IsNullOrEmpty(user.Password) && !String.IsNullOrEmpty(password))
            {
                return user.Password == password;
            }

            return false;
        }

        //validations
        public static string UserfieldsValidation(UserRecord user, string ensurePassword)
        {
            if (String.IsNullOrEmpty(user.Username) ||
                String.IsNullOrEmpty(user.FirstName) ||
                String.IsNullOrEmpty(user.LastName) ||
                String.IsNullOrEmpty(user.Password) ||
                String.IsNullOrEmpty(ensurePassword))
            {
                return "All fields are mandatory, please fill them.";
            }

            if (user.Password != ensurePassword)
            {
                return "Passwords do not match, check and try again.";
            }
            else
            {
                if (FileManager.UserNameExists(user.Username))
                {
                    return "Username already exists, try another one.";
                }
            }
            return "";
        }
            
    }
}