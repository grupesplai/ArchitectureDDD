using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Aplication.Interfaces
{
    public interface IService<T>
    {
        void Add(T model);
        List<T> GetAll();
    }
}
