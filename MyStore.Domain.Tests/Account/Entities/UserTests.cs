using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Specs;

namespace MyStore.Domain.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        [TestCategory("User - Entities")]
        public void CreateUser()
        {
            var user = new User("batman@dc.com", "batman", "123456");

            Assert.AreNotEqual(null, user);
        }
    }
}
