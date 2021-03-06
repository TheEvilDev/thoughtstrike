﻿using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;

namespace Ideastrike.Modules
{
    public class ControllersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(ThisAssembly);

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<ApiController>()
                   .AsSelf()
                   .InstancePerDependency();
        }
    }
}