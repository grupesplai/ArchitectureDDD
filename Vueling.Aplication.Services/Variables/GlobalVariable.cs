using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Aplication.Services
{
    public class GlobalVariable
    {
        public static HttpClient client = new HttpClient();

        static GlobalVariable()
        {
            client.BaseAddress = new Uri("http://www.mocky.io/v2/");
        }
    }
}
