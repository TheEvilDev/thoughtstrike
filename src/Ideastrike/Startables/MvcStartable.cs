using System.Web.Mvc;
using Autofac;

namespace Ideastrike.Startables
{
    public class MvcStartable : IStartable
    {
        private readonly IDependencyResolver _resolver;

        public MvcStartable(IDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public void Start()
        {
            DependencyResolver.SetResolver(_resolver);
            AreaRegistration.RegisterAllAreas();
        }
    }
}