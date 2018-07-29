using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Entity;

namespace Vueling.Aplication.Interfaces
{
    public interface IService<T>
    {
        T Add(T model);
        List<T> GetAll();
        T GetByID(string id);
        bool Remove(string id);
    }
}
