using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac;
using Ideastrike.Plumbing;

namespace Ideastrike.Modules
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(GlobalConfiguration.Configuration).As<HttpConfiguration>();
            builder.RegisterType<AutoFacCompositionRoot>().As<IHttpControllerActivator>().SingleInstance();
            builder.RegisterType<NamespaceHttpControllerSelector>().As<IHttpControllerSelector>().SingleInstance();
        }
    }
}