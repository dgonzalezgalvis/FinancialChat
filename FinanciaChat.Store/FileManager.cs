using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FinancialChat.Common.DTO;
using FinancialChat.Store.Classes;

namespace FinancialChat.Store
{
    public class FileManager
    {
        private static string usersFileName = "users.txt";
        private static string messagesFileName = "nessages.txt";
        private static string botMessagesFileName = "botmessages.txt";

        public static void CreateUser(UserRecord user)
        {
            var users = GetUsers();
            users.users.Add(user);
            XmlHelper.ToXmlFile(users, usersFileName);
        }

        public static void UpdateUser(UserRecord user)
        {
            var users = GetUsers();
            var tempUser = users.users.First(u => u.Username == user.Username);
            users.users.Remove(tempUser);
            tempUser.FirstName = user.Username;
            tempUser.LastName = user.LastName;
            tempUser.Password = user.Password;
            users.users.Add(user);
            XmlHelper.ToXmlFile(users, usersFileName);
        }

        public static Users GetUsers()
        {
            if (File.Exists(usersFileName))
            {
                return XmlHelper.FromXmlFile<Users>(usersFileName);
            }

            return new Users();
        }

        public static UserRecord GetUserInfo(string username)
        {
            return GetUsers().users.First(u => u.Username == username);
        }

        public static bool UserNameExists(string Username)
        {
            var users = GetUsers();
            if(users.users.Any(u => u.Username.Equals(Username)))
            {
                return true;
            }

            return false;
        }

        public static string Login(string Username, string Password)
        {
            var users = GetUsers();
            var user = users.users.FirstOrDefault(u => u.Username.Equals(Username));
            if(user == null)
            {
                return "User does not exists";
            }
            else
            {
                if(user.Password != Password)
                {
                    return "Password does not match";
                }
            }

            return "";
        }

        public static Chat GetMessages()
        {
            if (File.Exists(messagesFileName))
            {
                return XmlHelper.FromXmlFile<Chat>(messagesFileName);
            }

            return new Chat();
        }

        public static void SendMessage(Message message)
        {
            var chat = GetMessages();
            chat.messages.Add(message);
            XmlHelper.ToXmlFile(chat, messagesFileName);
        }

        public static void SendBotMessage(Message message)
        {
            var chat = GetMessages();
            chat.messages.Add(message);
            XmlHelper.ToXmlFile(chat, botMessagesFileName);
        }

        public static Chat GetBotMessages()
        {
            if (File.Exists(botMessagesFileName))
            {
                return XmlHelper.FromXmlFile<Chat>(botMessagesFileName);
            }

            return new Chat();
        }
    }
}
