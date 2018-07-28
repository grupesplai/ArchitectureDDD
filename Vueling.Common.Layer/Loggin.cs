using log4net;
using System;
using System.Reflection;
using Autofac;

namespace Vueling.Common.Layer
{
    public class Loggin
    {
        private static IContainer Container { get; set; }

        private readonly ILog _logger;
        public Loggin(ILog logger)
        {
            _logger = logger;
        }

        public void LogDebug(String message)
        {
            _logger.Debug(Resource3.DEBUG+ message);
        }

        public void LogError(String message)
        {
            _logger.Error(Resource3.ERROR + message);
        }

        public void LogTrace(String message)
        {
            _logger.Info(Resource3.TRACE+ message);
        }

    }
}
