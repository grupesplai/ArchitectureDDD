using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Vueling.Common.Entity;
using Vueling.Common.Layer;

namespace Vueling.Infrastructure.Repository
{
    public class ListCatcher
    {
        public static void GetAllList(HttpResponseMessage response)
        {
            List<Clients> lastList = null;
            DataSet dt = JsonUtilities<Clients>.ToReadString(response).Result;
            try
            {
                lastList = dt.Tables[Resource2.CLIENTS].AsEnumerable()
                            .Skip(1)
                            .Select(dr =>
                                    new Clients
                                    {
                                        id = dr.Field<string>(Resource2.ID),
                                        name = dr.Field<string>(Resource2.NAME),
                                        email = dr.Field<string>(Resource2.EMAIL),
                                        role = dr.Field<string>(Resource2.ROLE)
                                    }
                                    ).ToList();
            }
            catch (ArgumentNullException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(Resource2.E_ARG, ex.InnerException);
            }
            catch (AggregateException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(Resource2.E_AGRE, ex.InnerException);
            }
            ClientRepository.MakeJsonFile(lastList);//este envia el tipo de generico
        }
    }
}
