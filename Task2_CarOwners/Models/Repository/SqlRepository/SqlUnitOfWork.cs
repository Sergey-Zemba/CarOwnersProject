using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using Task2_CarOwners.Models.Context;

namespace Task2_CarOwners.Models.Repository.SqlRepository
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private CarOwnersContext db = new CarOwnersContext();
        private SqlOwnerRepository sqlOwnerRepository;
        private SqlCarRepository sqlCarRepository;

        public IRepository<Owner> Owners
        {
            get
            {
                if (sqlOwnerRepository == null)
                {
                    sqlOwnerRepository = new SqlOwnerRepository(db);
                }
                return sqlOwnerRepository;
            }
        }

        public IRepository<Car> Cars
        {
            get
            {
                if (sqlCarRepository == null)
                {
                    sqlCarRepository = new SqlCarRepository(db);
                }
                return sqlCarRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}