using Autofac;

namespace Ideastrike.Modules
{
    public class StartablesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<IStartable>()
		   .AsImplementedInterfaces()
                   .SingleInstance();
        }
    }
}