using System.Reflection;
using System.Web;
using Autofac;
using Ideastrike.Extensions;
using Ideastrike.Models.Repositories;

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
