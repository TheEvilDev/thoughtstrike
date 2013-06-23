using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;

namespace Ideastrike.Startables
{
    public class RegisterRoutesStartable : IStartable
    {
        private readonly RouteCollection _routes;

        public RegisterRoutesStartable(RouteCollection routes)
        {
            _routes = routes;
        }

        public void Start()
        {
            _routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            _routes.MapRoute(name: "NewIdea", url: "idea/new", defaults: new { controller = "Idea", action = "New" });
            _routes.MapRoute(name: "Idea", url: "idea/{id}/{action}", defaults: new { controller = "Idea", action = "Index", id = UrlParameter.Optional });
            _routes.MapRoute(name: "Comment", url: "comment/{id}/{action}", defaults: new { controller = "Comment", action = "Add" });

            _routes.MapRoute(
                name: "LogIn",
                url: "login/token",
                defaults: new { controller = "Token", action = "Login" }
            );

            _routes.MapRoute(
                name: "LogOut",
                url: "logout",
                defaults: new { controller = "Token", action = "Logout" }
            );

            _routes.MapRoute(
                name: "TopItems",
                url: "top",
                defaults: new { controller = "Home", action = "Top" }
            );

            _routes.MapRoute(
                name: "NewItems",
                url: "new",
                defaults: new { controller = "Home", action = "New" }
            );


            _routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}