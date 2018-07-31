using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialChat.Services;

namespace FinancialChat.Services.Test
{
    [TestClass]
    public class QueueServiceTest
    {
        [TestMethod]
        public void AccessEmptyQueue()
        {
            var response = QueueService.getMessage();
            Assert.AreEqual("", response, "Oops...");
        }

        [TestMethod]
        public void AccessFilledQueue()
        {
            QueueService.setMessage("test1");
            var response = QueueService.getMessage();
            Assert.AreEqual("test1", response, "Oops...");
        }

        [TestMethod]
        public void AccessSingleItemQueue()
        {
            QueueService.setMessage("test1");
            var response = QueueService.getMessage();
            response = QueueService.getMessage();
            Assert.AreEqual("", response, "Oops...");
        }

        [TestMethod]
        public void AccessMultipleItemQueue()
        {
            QueueService.setMessage("test1");
            QueueService.setMessage("test2");
            QueueService.setMessage("test3");
            var response = QueueService.getMessage();
            response = QueueService.getMessage();
            response = QueueService.getMessage();
            response = QueueService.getMessage();
            Assert.AreEqual("", response, "Oops...");
        }
    }
}
