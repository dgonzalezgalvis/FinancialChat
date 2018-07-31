using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinancialChat.Store;

namespace webapp1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxUsername.Text))
            {
                LabelResult.Text = "Please fill username value.";
                return;
            }
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                LabelResult.Text = "Please fill password value.";
                return;
            }

            var result = FileManager.Login(TextBoxUsername.Text, TextBoxPassword.Text);
            LabelResult.Text = result;

            if (result == "")
            {
                Hashtable htblGlobalValues = null;

                if (Application["GlobalValueKey"] != null)
                {
                    htblGlobalValues = Application["GlobalValueKey"] as Hashtable;
                }
                else
                {
                    htblGlobalValues = new Hashtable();
                }

                htblGlobalValues.Add("Username", TextBoxUsername.Text);
                this.Application["GlobalValueKey"] = htblGlobalValues;
                Response.Redirect("/Pages/Chat.aspx");
            }
        }
    }
}