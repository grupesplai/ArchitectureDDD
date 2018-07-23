using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace Vueling.Common.Layer
{
    public class Loggin
    {
        private static ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Loggin()
        {
        }

        public static void LogDebug(String message)
        {
            log.Debug(Resource3.DEBUG+ message);
        }

        public static void LogError(String message)
        {
            log.Error(Resource3.ERROR + message);
        }

        public static void LogTrace(String message)
        {
            log.Info(Resource3.TRACE+ message);
        }

    }
}
