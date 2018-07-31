using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialChat.Common.DTO;
using webapp1.Common;

namespace FinancialChat.WebApp.Test
{
    [TestClass]
    public class UserValidationTest
    {
        [TestMethod]
        public void UserValidationValidateUserCreation()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "Rivera", "1234");
            Assert.IsNotNull(user);
            Assert.AreEqual<UserRecord>(user, user);
            Assert.AreEqual(user.Username, "user");
            Assert.AreEqual(user.FirstName, "Jose");
            Assert.AreEqual(user.LastName, "Rivera");
            Assert.AreEqual(user.Password, "1234");
        }

        [TestMethod]
        public void UserValidationValidatePassword()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "Rivera", "1234");
            var result = UserValidation.ValidatePassword(user, "123");
            Assert.AreEqual<bool>(result, false, "Oops...");
        }

        [TestMethod]
        public void UserValidationValidatePasswordTrue()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "Rivera", "1234");
            var result = UserValidation.ValidatePassword(user, "1234");
            Assert.AreEqual<bool>(result, true, "Oops...");
        }

        [TestMethod]
        public void UserValidationValidateEmptyUsername()
        {
            UserRecord user = UserValidation.CreateUserRecord("", "Jose", "Rivera", "1234");
            var result = UserValidation.UserfieldsValidation(user, "1234");
            Assert.AreEqual(result, "All fields are mandatory, please fill them.", "Oops...");
        }

        [TestMethod]
        public void UserValidationValidateEmptyFirstname()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "", "Rivera", "1234");
            var result = UserValidation.UserfieldsValidation(user, "1234");
            Assert.AreEqual(result, "All fields are mandatory, please fill them.", "Oops...");
        }

        [TestMethod]
        public void UserValidationValidateEmptyLastname()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "", "1234");
            var result = UserValidation.UserfieldsValidation(user, "1234");
            Assert.AreEqual(result, "All fields are mandatory, please fill them.", "Oops...");
        }

        [TestMethod]
        public void UserValidationValidateEmptyPassword()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "Rivera", "");
            var result = UserValidation.UserfieldsValidation(user, "1234");
            Assert.AreEqual(result, "All fields are mandatory, please fill them.", "Oops...");
        }

        [TestMethod]
        public void UserValidationValidateMatchPassword()
        {
            UserRecord user = UserValidation.CreateUserRecord("user", "Jose", "Rivera", "1234");
            var result = UserValidation.UserfieldsValidation(user, "123");
            Assert.AreEqual(result, "Passwords do not match, check and try again.", "Oops...");
        }
    }
}
