using FinancialChat.Store;
using System;
using System.Collections;
using System.Web.UI;
using FinancialChat.Common.DTO;
using FinancialChat.Services;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client.Events;
using webapp1.Common;

namespace webapp1
{
    public partial class Contact : Page
    {
        private string username;
        private static string response;

        protected void Page_Load(object sender, EventArgs e)
        {
            username = "";
            Hashtable htblGlobalValues = null;

            var loggedUser = SessionController.GetUsername(Application);
            if (loggedUser != "")
            {
                username = loggedUser;
                if (ListBox1.Items.Count == 0)
                {
                    GetMessages();
                }
            }
            else
            {
                Response.Redirect("~/");
            }                 
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
            var message = QueueService.getMessage();
            if(message != "")
            {
                ListBox1.Items.Add(message);
                
                UpdatePanel1.Update();
            }
        }

        protected void SendMessage(object sender, EventArgs e)
        {
            var writtenMessage = TextBoxMessage.Text;
            if (writtenMessage != ""){
                TextBoxMessage.Text = "";
                if (BotMessage(writtenMessage))
                {
                    ProcessBotMessage(writtenMessage);
                }
                else
                {
                    var message = new Message();
                    message.MessageContent = writtenMessage;
                    message.Username = username;
                    message.date = DateTime.Now;
                    FileManager.SendMessage(message);
                    GetMessages();
                }
                
            }
        }

        protected void GetMessages()
        {
            ListBox1.Items.Clear();
            var messages = FileManager.GetMessages();
            var index = 0;
            messages.messages.ForEach(m => {
                if(index < 50)
                {
                    var message = m.Username + " (" + m.date + "): " + m.MessageContent;
                    ListBox1.Items.Add(message);
                    index++;
                }
                
            });
        }

        protected bool BotMessage(string writtenMessage)
        {
            if (writtenMessage != "" && writtenMessage[0].Equals('/'))
            {
                return true;
            }

            return false;
        }

        protected void ProcessBotMessage(string writtenMessage)
        {
            
            RabbitMQService.PublishMessage(writtenMessage);
            var result = RabbitMQService.GetMessages();
            GetBotMessages();
        }

        private void GetBotMessages()
        {
            var messages = FileManager.GetBotMessages();
            messages.messages.ForEach(m => {
                var message = m.Username + " (" + m.date + "): " + m.MessageContent;
                ListBox1.Items.Add(message);
            });
            
        }

        private static async Task ConsumerReceived(object sender, BasicDeliverEventArgs ea)
        {
            var body = ea.Body;
            var message = Encoding.UTF8.GetString(body);
            await Task.Delay(250);
            response = message;
        }
    }
}