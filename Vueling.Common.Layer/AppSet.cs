using System.Configuration;

namespace Vueling.Common.Layer
{
    public class AppSet
    {
        public static string AppTxts(string resource)
        {
            return ConfigurationManager.AppSettings[resource];
        }
    }
}
