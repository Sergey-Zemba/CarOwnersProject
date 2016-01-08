using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_CarOwners.Models.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetList();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);

    }
}
