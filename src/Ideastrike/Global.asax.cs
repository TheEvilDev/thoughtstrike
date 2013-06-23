using System.Configuration;
using System.Data.Entity.Migrations;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Ideastrike.Extensions;
using Ideastrike.Migrations;
using Ideastrike.Models;
using Ideastrike.Models.Repositories;
using Ideastrike.Modules;

namespace Ideastrike
{
    public class MvcApplication : HttpApplication
    {
        private IContainer _container;

        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
	    builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            _container = builder.Build();

            UserRepository = _container.Resolve<IUserRepository>();
        }

	protected void Application_End()
	{
	    _container.Dispose();
	}

        public static IUserRepository UserRepository { get; set; }
    }
}
