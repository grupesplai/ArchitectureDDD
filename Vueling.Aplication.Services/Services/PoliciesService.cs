using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Vueling.Aplication.Interfaces;
using Vueling.Common.Entity;
using Vueling.Common.Layer;
using Vueling.Infrastructure.Interfaces;
using Vueling.Infrastructure.Repository;

namespace Vueling.Aplication.Services
{
    public class PoliciesService : IService<Policies>
    {
        private readonly IRepository<Policies> iRepository;

        public async void Add(Policies policy)
        {
            var alumnoJSON = JsonConvert.SerializeObject(policy, Formatting.Indented);

            var encodingToBytes = Encoding.UTF8.GetBytes(alumnoJSON);
            var byteContent = new ByteArrayContent(encodingToBytes);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue(ConfigurationManager.AppSettings[Resource1.APIJSON]);

            var result = await GlobalVariable.client.PostAsync(ConfigurationManager.AppSettings[Resource1.URIPOL], byteContent);
        }
        
        public List<Policies> GetAll()
        {
            List<Policies> lastList = null;
            HttpResponseMessage response = Manager.HttpClient.GetDataWeb(Resource1.URIPOL);

            if (response.IsSuccessStatusCode)
            {
                lastList = GetAllList(response);
            }
            return lastList;
        }

        public List<Policies> GetAllList(HttpResponseMessage response)
        {
            List<Policies> lastList = null;
            DataSet dt = Manager.HttpClient.ToReadString(response).Result;
            try
            {
                lastList = dt.Tables[Resource1.POLICY].AsEnumerable()
                        .Skip(1)
                        .Select(dr =>
                                new Policies
                                {
                                    id = dr.Field<string>(Resource1.ID),
                                    amountInsured = dr.Field<double>(Resource1.AMOUNT),
                                    email = dr.Field<string>(Resource1.EMAIL),
                                    inceptionDate = dr.Field<DateTime>(Resource1.DATE),
                                    installmentPayment = dr.Field<bool>(Resource1.PAY),
                                    clientId = dr.Field<string>(Resource1.CLIENTID)
                                }).ToList();
            }

            catch (ArgumentNullException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource1.E_ARG, ex.InnerException);
            }
            PoliciesRepository.GetJson(lastList);
            return lastList;
        }
    }
}
