using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Autofac;

namespace Ideastrike.Plumbing
{
    public class AutoFacCompositionRoot : IHttpControllerActivator
    {
        private readonly IComponentContext _context;

        public AutoFacCompositionRoot(IComponentContext context)
        {
            _context = context;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)_context.Resolve(controllerType);

            return controller;
        }
    }
}