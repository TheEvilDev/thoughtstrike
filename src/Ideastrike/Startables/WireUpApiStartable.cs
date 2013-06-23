using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac;

namespace Ideastrike.Startables
{
    public class WireUpApiStartable : IStartable
    {
        private readonly HttpConfiguration _config;
        private readonly IHttpControllerActivator _controllerActivator;
        private readonly IHttpControllerSelector _controllerSelector;

        public WireUpApiStartable(HttpConfiguration config,
                                  IHttpControllerActivator controllerActivator,
                                  IHttpControllerSelector controllerSelector)
        {
            _config = config;
            _controllerActivator = controllerActivator;
            _controllerSelector = controllerSelector;
        }

        public void Start()
        {
            // _config.Filters.Add(new AuthorizeAttribute());
            _config.Services.Replace(typeof (IHttpControllerActivator), _controllerActivator);
            _config.Services.Replace(typeof (IHttpControllerSelector), _controllerSelector);

            _config.Routes.MapHttpRoute(
                name: "VersionedApi",
                routeTemplate: "api/{namespace}/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            _config.Routes.MapHttpRoute(
                name: "CurrentApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {@namespace = "v1", id = RouteParameter.Optional}
                );
        }
    }
}