using System;
using System.Net.Http;
using Vueling.Common.Layer;

namespace Vueling.Aplication.Services.Manager
{
    public class HttpClient 
    {
        public static HttpResponseMessage GetDataWeb(string uri)
        {
            HttpResponseMessage response = null;
            try
            {
                 response = GlobalVariable.client.GetAsync(
                  AppSet.AppTxts(uri)).Result;
            }
            catch(HttpRequestException ex)
            {
                //Loggin.LogError(ex.Message);
                //Loggin.LogError(ex.StackTrace);
                throw new VuelingException(Resource1.E_HTTP, ex.InnerException);
            }
            catch (ArgumentNullException ex)
            {
                //Loggin.LogError(ex.Message);
                //Loggin.LogError(ex.StackTrace);
                throw new VuelingException(Resource1.E_ARG, ex.InnerException);
            }
            return response;
        }

        
    }
}
