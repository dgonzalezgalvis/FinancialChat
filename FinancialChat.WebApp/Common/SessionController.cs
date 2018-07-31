using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapp1.Common
{
    public class SessionController
    {
        public static string GetUsername(HttpApplicationState application)
        {
            Hashtable htblGlobalValues = null;

            if (application["GlobalValueKey"] != null)
            {
                htblGlobalValues = application["GlobalValueKey"] as Hashtable;
                if (htblGlobalValues.ContainsKey("Username"))
                {
                    return htblGlobalValues["Username"].ToString();
                }
            }

            return "";
        }
    }
}