using System;
using System.Collections.Generic;
using System.Data.Entity;
using Task2_CarOwners.Models.Context;

namespace Task2_CarOwners.Models.Repository.SqlRepository
{
    public class SqlOwnerRepository : IRepository<Owner>
    {
        private CarOwnersContext db;

        public SqlOwnerRepository(CarOwnersContext context)
        {
            db = context;
        }
        public IEnumerable<Owner> GetList()
        {
            return db.Owners;
        }

        public Owner GetItem(int id)
        {
            return db.Owners.Find(id);
        }

        public void Create(Owner item)
        {
            db.Owners.Add(item);
        }

        public void Update(Owner item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner != null)
            {
                db.Owners.Remove(owner);
            }
        }


    }
}