using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac;

namespace Ideastrike.Modules
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(GlobalConfiguration.Configuration).As<HttpConfiguration>();
            // builder.RegisterType<AutofacControllerActivator>().As<IHttpControllerActivator>().SingleInstance();
        }
    }
}