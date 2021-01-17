using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Scopes;
using MyStore.Domain.Account.Specs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Domain.Tests.Account
{
    [TestClass]
    public class UserSpecsTests
    {
        private List<User> _users;

        public UserSpecsTests()
        {
            _users = new List<User>();
            _users.Add(new User("batman@dc.com", "batman", "123456"));
            _users.Add(new User("flash@dc.com", "flash", "123456"));
            _users.Add(new User("ironman@marve.com", "ironman", "123456"));
            _users.Add(new User("spiderman@dc.com", "spiderman", "123456"));

        }
        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameShouldReturnValue()
        {
            var result = _users.AsQueryable().Where(UserSpecs.GetUserByName("batman")).FirstOrDefault();

            Assert.AreEqual(result.Username, "batman");
        }

        [TestMethod]
        [TestCategory("User - Specs")]
        public void GetByUserNameShouldNotReturnValue()
        {
            var result = _users.AsQueryable().Where(UserSpecs.GetUserByName("superman")).FirstOrDefault();

            Assert.AreEqual(null, result);
        }

    }
}
