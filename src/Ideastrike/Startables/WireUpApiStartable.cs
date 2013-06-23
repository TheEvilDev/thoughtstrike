using System.Web.Http;
using System.Web.Http.Dispatcher;
using Autofac;
using Ideastrike.MessageHandlers;

namespace Ideastrike.Startables
{
    public class WireUpApiStartable : IStartable
    {
        private readonly ApiKeyHandler _apiKeyHandler;
        private readonly HttpConfiguration _config;
        private readonly IHttpControllerActivator _controllerActivator;
        private readonly IHttpControllerSelector _controllerSelector;

        public WireUpApiStartable(HttpConfiguration config,
                                  IHttpControllerActivator controllerActivator,
                                  IHttpControllerSelector controllerSelector,
                                  ApiKeyHandler apiKeyHandler)
        {
            _config = config;
            _controllerActivator = controllerActivator;
            _controllerSelector = controllerSelector;
            _apiKeyHandler = apiKeyHandler;
        }

        public void Start()
        {
            // _config.Filters.Add(new AuthorizeAttribute());
            _config.Services.Replace(typeof (IHttpControllerActivator), _controllerActivator);
            _config.Services.Replace(typeof (IHttpControllerSelector), _controllerSelector);

            _config.Routes.MapHttpRoute(
                name: "VersionedApi",
                routeTemplate: "api/{namespace}/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional},
                handler: _apiKeyHandler,
                constraints: null
                );

            _config.Routes.MapHttpRoute(
                name: "CurrentApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {@namespace = "v1", id = RouteParameter.Optional},
                constraints: null,
                handler: _apiKeyHandler
                );
        }
    }
}