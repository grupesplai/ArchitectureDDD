using System;
using System.Collections.Generic;

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
