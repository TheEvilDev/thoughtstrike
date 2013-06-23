using System.Web.Mvc;
using Autofac;

namespace Ideastrike.Startables
{
    public class RegisterGlobalFiltersStartable : IStartable
    {
        private readonly GlobalFilterCollection _filters;

        public RegisterGlobalFiltersStartable(GlobalFilterCollection filters)
        {
            _filters = filters;
        }

        public void Start()
        {
            _filters.Add(new HandleErrorAttribute());
        }
    }
}