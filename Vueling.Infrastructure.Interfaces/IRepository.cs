using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Infrastructure.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetByID(string id);
        bool Remove(string id);
    }
}
