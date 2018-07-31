using FinancialChat.Store;
using FinancialChat.Store.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using webapp1.Common;
using FinancialChat.Common.DTO;

namespace webapp1
{
    public partial class Profile : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var loggedUser = SessionController.GetUsername(Application);
            if (loggedUser != "")
            {
                var userInfo = FileManager.GetUserInfo(loggedUser);
                TextBoxFirstname.Text = userInfo.FirstName;
                TextBoxLastname.Text = userInfo.LastName;
                TextBoxUsername.Text = userInfo.Username;
                TextBoxPassword.Text = userInfo.Password;
                TextBoxPassword2.Text = userInfo.Password;
                GetMessages();
            }
            else
            {
                Response.Redirect("~/");
            }
        }

        protected void GetMessages()
        {
            ListBox1.Items.Clear();
            var messages = FileManager.GetMessages();
            messages.messages.ForEach(m => {
                var message = m.Username + " (" + m.date + "): " + m.MessageContent;
                ListBox1.Items.Add(message);
            });
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = UserValidation.CreateUserRecord(TextBoxUsername.Text,
                TextBoxFirstname.Text,
                TextBoxLastname.Text,
                TextBoxPassword.Text);
            //validations
            LabelError.Text = UserValidation.UserfieldsValidation(user, TextBoxPassword2.Text);
            if (LabelError.Text == "")
            {
                FileManager.UpdateUser(user);
                Response.Redirect("../Default.aspx");
            }

        }
    }
}