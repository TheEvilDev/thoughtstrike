using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace Ideastrike.Modules
{
    public class MvcModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutofacDependencyResolver>().As<IDependencyResolver>().SingleInstance();
            builder.RegisterInstance(GlobalFilters.Filters).As<GlobalFilterCollection>().SingleInstance();
	    builder.RegisterInstance(RouteTable.Routes).As<RouteCollection>().SingleInstance();
            builder.RegisterFilterProvider();
        }
    }
}