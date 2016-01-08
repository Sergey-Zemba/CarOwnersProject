using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_CarOwners.Models.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Owner> Owners { get; }
        IRepository<Car> Cars { get; }
        void Save();
    }
}
