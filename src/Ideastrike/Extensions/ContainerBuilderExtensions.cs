using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;

namespace Ideastrike.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static void RegisterAssemblyModules(this ContainerBuilder builder, Assembly assembly)
        {
            foreach (var module in assembly.GetExportedTypes().Where(t => TypeExtensions.IsAssignableTo<IModule>(t)))
            {
                builder.RegisterModule(Activator.CreateInstance(module) as IModule);
            }
        }
    }
}