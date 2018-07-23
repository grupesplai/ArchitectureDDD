using Vueling.Common.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Aplication.Interfaces;
using System.Net.Http.Headers;
using System.Data;
using System.Configuration;
using Vueling.Common.Layer;
using Vueling.Aplication.Services.Manager;
using Vueling.Infrastructure.Interfaces;
using Vueling.Infrastructure.Repository;
using System;
using System.Linq;

namespace Vueling.Aplication.Services
{
    public class ClientServices : IService<Clients>
    {
        private readonly IRepository<Clients> iRepository;

        public async void Add(Clients client)
        {
            var alumnoJSON = JsonConvert.SerializeObject(client, Formatting.Indented);

            var encodingToBytes = Encoding.UTF8.GetBytes(alumnoJSON);
            var byteContent = new ByteArrayContent(encodingToBytes);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue(
                ConfigurationManager.AppSettings[Resource1.APIJSON]);

            var result = await GlobalVariable.client.PostAsync(
                ConfigurationManager.AppSettings[Resource1.URICLI], byteContent);
        }

        public List<Clients> GetAll()
       {
            List<Clients> lastList = null;
            HttpResponseMessage response = Manager.HttpClient.GetDataWeb(Resource1.URICLI);

            if (response.IsSuccessStatusCode)
                lastList = GetAllList(response);

            return lastList;
        }

        public List<Clients> GetAllList(HttpResponseMessage response)
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
