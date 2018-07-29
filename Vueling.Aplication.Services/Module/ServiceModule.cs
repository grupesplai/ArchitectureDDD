using Autofac;
using Vueling.Common.Layer.Log4net;
using Vueling.Infrastructure.Interfaces;
using Vueling.Infrastructure.Repository;

namespace Vueling.Aplication.Services
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder
            //    .RegisterType<ClientRepository>()
            //    .As<IRepository>()
            //    .InstancePerRequest();

            builder
                .RegisterType<Log4netAdapter>()
                .As<ILogger>()
                .InstancePerRequest();


            // Cada module, se encarga de inyectar las clases de su capa
            builder.RegisterModule(new RepositoryModule());

            base.Load(builder);
        }
    }
}
