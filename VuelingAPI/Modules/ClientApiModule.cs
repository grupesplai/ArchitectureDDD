using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Reflection;
using Vueling.Aplication.Interfaces;
using Vueling.Aplication.Services;
using Vueling.Common.Layer.Log4net;

namespace VuelingAPI.Modules
{
    public class ClientApiModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //builder
            //    .RegisterType<ClientServices>()
            //    .As<IService>()
            //    .InstancePerRequest();
            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();

            builder.RegisterModule(new ServiceModule());
            base.Load(builder);
        }
    }
}