using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialChat.Common.DTO;

namespace FinancialChat.Common.Test
{
    [TestClass]
    public class UserRecordTest
    {
        [TestMethod]
        public void UserRecordSetUsername()
        {
            var ur = new UserRecord();
            ur.Username = "username";
            Assert.AreEqual("username", ur.Username, "Oops...");
        }

        [TestMethod]
        public void UserRecordSetPassword()
        {
            var ur = new UserRecord();
            ur.Password = "password";
            Assert.AreEqual("password", ur.Password, "Oops...");
        }

        [TestMethod]
        public void UserRecordSetFirstname()
        {
            var ur = new UserRecord();
            ur.FirstName = "FirstName";
            Assert.AreEqual("FirstName", ur.FirstName, "Oops...");
        }

        [TestMethod]
        public void UserRecordSetLastname()
        {
            var ur = new UserRecord();
            ur.LastName = "LastName";
            Assert.AreEqual("LastName", ur.LastName, "Oops...");
        }
    }
}
