using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Layer
{
    public class JsonUtilities
    {
        public static DataSet Desearializer(string jsonString)
        {
            DataSet dt = null;
            try
            {
                dt = JsonConvert.DeserializeObject<DataSet>(jsonString);
            }
            catch (JsonWriterException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(ex.Message, ex.InnerException);
            }
            catch (JsonSerializationException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JSERIA, ex.InnerException);
            }
            catch (JsonReaderException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JREAD, ex.InnerException);
            }
            catch (JsonException ex)
            {
                Loggin.LogError(ex.Message);
                throw new VuelingException(Resource3.E_JEXCE, ex.InnerException);
            }
            return dt;
        }
    }
}
