using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace Vueling.Common.Layer
{
    public class JsonUtilities<T>
    {
        public static async Task<DataSet> ToReadString(HttpResponseMessage response)
        {
            try
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                DataSet listJson = JsonConvert.DeserializeObject<DataSet>(jsonString);

                return listJson;
            }
            catch (JsonWriterException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(ex.Message, ex.InnerException);
            }
            catch (JsonSerializationException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JSERIA, ex.InnerException);
            }
            catch (JsonReaderException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JREAD, ex.InnerException);
            }
            catch (JsonException ex)
            {
                //Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JEXCE, ex.InnerException);
            }
        }
        public static string ToSerializeObject(List<T> list)
        {
            return JsonConvert.SerializeObject(list, Formatting.Indented);
        }
        public static List<T> ToDeserialize(string jsonData)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}
