using FinancialChat.Store;
using FinancialChat.Store.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinancialChat.Common.DTO;
using webapp1.Common;

namespace webapp1
{
    public partial class Signup : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var user = UserValidation.CreateUserRecord(TextBoxUsername.Text,
                TextBoxFirstname.Text,
                TextBoxLastname.Text,
                TextBoxPassword.Text);
            //validations
            LabelError.Text = UserValidation.UserfieldsValidation(user, TextBoxPassword2.Text);
            if(LabelError.Text == "")
            {
                LabelError.Text = "";
                FileManager.CreateUser(user);
                Response.Redirect("../Default.aspx");
            }

        }
    }
}