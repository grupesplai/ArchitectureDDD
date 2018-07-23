using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Entity;

namespace Vueling.Aplication.Interfaces
{
    public interface IHttpResponse<T>
    {
       //Task<List<T>> ToReadString(HttpResponseMessage response);
        List<T> GetAllList(HttpResponseMessage response);
    }
}
