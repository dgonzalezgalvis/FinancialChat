using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialChat.Common.DTO;

namespace FinancialChat.Common.Test
{
    [TestClass]
    public class MessageTest
    {
        [TestMethod]
        public void MessageSetDate()
        {
            var m = new Message();
            m.date = DateTime.Now; ;
            Assert.AreEqual(DateTime.Now, m.date, "Oops...");
        }

        [TestMethod]
        public void MessageSetMessageContent()
        {
            var m = new Message();
            m.MessageContent = "aosjdpaojdopsjsdpoda";
            Assert.AreEqual("aosjdpaojdopsjsdpoda", m.MessageContent, "Oops...");
        }

        [TestMethod]
        public void UserRecordSetFirstname()
        {
            var m = new Message();
            m.Username = "username";
            Assert.AreEqual("username", m.Username, "Oops...");
        }
    }
}
