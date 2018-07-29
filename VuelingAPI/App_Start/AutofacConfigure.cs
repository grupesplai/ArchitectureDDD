using Autofac;
using Autofac.Integration.WebApi;
using System.Web.Http;
using VuelingAPI.Modules;

namespace VuelingAPI.App_Start
{
    public class AutofacConfigure
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new ClientApiModule());

            var container = builder.Build();

            // El que resuelve todas las clases registradas -> AutofacWebApiDependencyResolver
            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            return container;
        }
    }
}