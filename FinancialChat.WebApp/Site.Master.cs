using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinancialChat.Store;
using webapp1.Common;

namespace webapp1
{
    public partial class SiteMaster : MasterPage
    {
        private string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelUsername.Text = "";
            username = "";
            NavAnonymous.Visible = true;
            NavLogged.Visible = false;
            var loggedUser = SessionController.GetUsername(Application);
            if (loggedUser != "")
            {
                username = loggedUser;
                LabelUsername.Text = "Welcome, " + username;
                NavAnonymous.Visible = false;
                NavLogged.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Hashtable htblGlobalValues = Application["GlobalValueKey"] as Hashtable;
            if (htblGlobalValues.ContainsKey("Username"))
            {
                htblGlobalValues.Remove("Username");
                Response.Redirect("~/");
            }
        }
    }
}