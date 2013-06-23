using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace Ideastrike.Helpers
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterAssemblyModules(this ContainerBuilder builder, Assembly assembly)
        {
            foreach (var module in assembly.GetExportedTypes().Where(t => t.IsAssignableTo<IModule>()))
            {
                builder.RegisterModule(Activator.CreateInstance(module) as IModule);
            }
        }
    }
}