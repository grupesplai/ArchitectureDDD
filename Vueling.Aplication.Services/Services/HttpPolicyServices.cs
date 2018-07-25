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
    public class HttpPolicyServices
    {
        static WebClient client;
        static HttpPolicyServices()
        {
            client = new WebClient();
        }

        public static List<Policies> GetCall()//desearliza la web
        {
            List<Policies> lastList = null;
            HttpResponseMessage response = Manager.HttpClient.GetDataWeb(Resource1.URIPOL);

            if (response.IsSuccessStatusCode)
                lastList = GetAllList(response);

            return lastList;

        }
        public static List<Policies> GetAllList(HttpResponseMessage response)
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
