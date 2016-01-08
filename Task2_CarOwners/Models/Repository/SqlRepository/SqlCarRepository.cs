using System;
using System.Collections.Generic;
using System.Data.Entity;
using Task2_CarOwners.Models.Context;

namespace Task2_CarOwners.Models.Repository.SqlRepository
{
    public class SqlCarRepository : IRepository<Car>
    {
        private CarOwnersContext db;

        public SqlCarRepository(CarOwnersContext context)
        {
            db = context;
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


    }
}