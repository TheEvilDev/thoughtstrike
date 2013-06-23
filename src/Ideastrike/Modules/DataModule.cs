using System.Configuration;
using System.Data.Entity.Migrations;
using Autofac;
using Ideastrike.Migrations;
using Ideastrike.Models;

namespace Ideastrike.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            if (ConfigurationManager.ConnectionStrings.Count > 0 && ConfigurationManager.ConnectionStrings["Ideastrike"] != null)
                builder.RegisterType<IdeastrikeContext>()
                    .WithParameter(new NamedParameter("nameOrConnectionString", ConfigurationManager.ConnectionStrings["Ideastrike"].ConnectionString + ";MultipleActiveResultSets=true"))
                    .AsSelf()
                    .InstancePerLifetimeScope();

            else
                builder.RegisterType<IdeastrikeContext>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<IdeastrikeDbConfiguration>().As<DbMigrationsConfiguration>().SingleInstance();
            builder.RegisterType<DbMigrator>().AsSelf().SingleInstance();
        }
    }
}