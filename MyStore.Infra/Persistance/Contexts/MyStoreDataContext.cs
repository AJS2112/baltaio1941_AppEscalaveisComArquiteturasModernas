using MyStore.Domain.Account.Entities;
using MyStore.Infra.Persistance.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Persistance.Contexts
{
    public class MyStoreDataContext : DbContext
    {
        public MyStoreDataContext() : base("MyStoreConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMappings());
        }
    }
}
