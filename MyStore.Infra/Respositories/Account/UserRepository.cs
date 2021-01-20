using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Specs;
using MyStore.Infra.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Respositories.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly MyStoreDataContext _context;

        public UserRepository(MyStoreDataContext context)
        {
            _context = context;
        }

        public User GetByAuthorizationCode(string authorizationCode)
        {
            return _context.Users.Where(UserSpecs.GetByAutorizationCode(authorizationCode)).FirstOrDefault();
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.Where(UserSpecs.GetUserByName(userName)).FirstOrDefault();
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
