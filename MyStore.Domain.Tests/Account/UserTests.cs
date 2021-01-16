using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;

namespace MyStore.Domain.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void VerificaUsuario()
        {
            var user = new User("Antonio","123456");
            user.Verify("1234");

            Assert.AreEqual(true, user.Verified);
        }
    }
}
