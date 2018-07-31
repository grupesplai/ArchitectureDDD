using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Entity;
using Vueling.Common.Layer;
using Vueling.Infrastructure.Repository;

namespace Vueling.Aplication.Services.Services
{
    public class HttpClientServices
    {
            static WebClient client;
            static HttpClientServices()
            {
                client = new WebClient();
            }

            public static void GetJsonFromWeb()//Metodo inicial que tiene que desearlizar la web
            {
                HttpResponseMessage response = Manager.HttpClient.GetDataWeb(Resource1.URICLI);
                if (response.IsSuccessStatusCode)
                    ListCatcher.GetAllList(response);
            }
    }
}
