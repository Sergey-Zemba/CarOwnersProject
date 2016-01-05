using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Task2_CarOwners.Models.Context;

namespace Task2_CarOwners.Models.Repository
{
    public class SqlCarRepository : IRepository<Car>
    {
        private CarOwnersContext db;

        public SqlCarRepository()
        {
            db = new CarOwnersContext();
        }
        public IEnumerable<Car> GetList()
        {
            return db.Cars;
        }

        public Car GetItem(int id)
        {
            return db.Cars.Find(id);
        }

        public void Create(Car item)
        {
            db.Cars.Add(item);
        }

        public void Update(Car item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Car car = db.Cars.Find(id);
            if (car != null)
            {
                db.Cars.Remove(car);
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}