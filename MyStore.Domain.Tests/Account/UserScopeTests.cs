using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Scopes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Tests.Account
{
    [TestClass]
    public class UserScopeTests
    {
        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterUserScopedIsValid()
        {
            var user = new User("batman@dc.com", "batman", "123456");

            Assert.AreEqual(true, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void RegisterUserScopedIsInvalidWhenUserNameIsNull()
        {
            var user = new User("batman@dc.com", "", "123456");

            Assert.AreEqual(false, user.RegisterScopeIsValid());
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationUserScopedIsValid()
        {
            var user = new User("batman@dc.com", "batman", "123456");
            var verificationCode = user.VerificationCode;

            Assert.AreEqual(true, user.VerificationScopeIsValid(verificationCode));
        }

        [TestMethod]
        [TestCategory("User - Scopes")]
        public void VerificationUserScopedIsInvalid()
        {
            var user = new User("batman@dc.com", "batman", "123456");
            var verificationCode = "23456";

            Assert.AreEqual(false, user.VerificationScopeIsValid(verificationCode));
        }
    }
}
