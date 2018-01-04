using System;
using System.Collections.Generic;
using System.Text;
using MessagesManager.Startup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CRUDChannelTests
    {
        IMessagesManager messageManager = null;

        [TestInitialize]
        public void init()
        {
            string userId = "123456789";
            messageManager = new MessageManagerImpl(userId);
        }



        [TestMethod]
        public void addChannelTest()
        {

            Assert.AreEqual("", "");
        }


        [TestCleanup]
        public void finish()
        {
            messageManager = null;
        }

    }
}
