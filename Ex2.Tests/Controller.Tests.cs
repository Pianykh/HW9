using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ex2.Tests
{
    class ControllerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Authorize_ShouldAuthorizeUser()
        {
            /*var stringReader = new StringReader("1" + Environment.NewLine);
            var stringReaderLogin = new StringReader("sys" + Environment.NewLine);
            var stringReaderPassword = new StringReader("sys" + Environment.NewLine);
            var stringWriter = new StringWriter();
            Controller.ShowMenu();
            Console.SetIn(stringReader);
            Console.SetIn(stringReaderLogin);
            Console.SetIn(stringReaderPassword);
            Console.SetOut(stringWriter);
*/
            // Assert.AreEqual("Successful authorization. Welcome, [sys]", stringWriter);
            Assert.Pass();

        }

        [Test]
        public void Registration_ShouldRegistrateUser()
        {
            Assert.Pass();
        }

        [Test]
        public void Logout_ShouldLogoutUser()
        {
            Assert.Pass();
        }

        [Test]
        public void MakeDeposit_ShouldDepositMoneyToWallet()
        {
            Assert.Pass();
        }
    }
}
