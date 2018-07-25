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

        public static List<Clients> GetCall()//desearliza la web
        {
            List<Clients> lastList = null;
            HttpResponseMessage response = Manager.HttpClient.GetDataWeb(Resource1.URICLI);

            if (response.IsSuccessStatusCode)
                lastList = GetAllList(response);

            return lastList;

        }
        public static List<Clients> GetAllList(HttpResponseMessage response)
        {
            List<Clients> lastList = null;
            DataSet dt = Manager.HttpClient.ToReadString(response).Result;
            try
            {
                lastList = dt.Tables[Resource1.CLIENTS].AsEnumerable()
                            .Skip(1)
                            .Select(dr =>
                                    new Clients
                                    {
                                        id = dr.Field<string>(Resource1.ID),
                                        name = dr.Field<string>(Resource1.NAME),
                                        email = dr.Field<string>(Resource1.EMAIL),
                                        role = dr.Field<string>(Resource1.ROLE)
                                    }
                                    ).ToList();
            }
            catch (ArgumentNullException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource1.E_ARG, ex.InnerException);
            }
            catch (AggregateException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource1.E_AGRE, ex.InnerException);
            }
            ClientRepository.GetJson(lastList);
            return lastList;
        }
    }
}
