using MyStore.Infra.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyStoreDataContext _context;

        public UnitOfWork(MyStoreDataContext context)
        {
            _context = context;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Nada :)
        }
    }
}
