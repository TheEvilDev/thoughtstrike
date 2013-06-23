using System.Data.Entity.Migrations;
using Autofac;

namespace Ideastrike.Startables
{
    public class MigrateDatabaseStartable : IStartable
    {
        private readonly DbMigrator _migrator;

        public MigrateDatabaseStartable(DbMigrator migrator)
        {
            _migrator = migrator;
        }

        public void Start()
        {
            _migrator.Update();
        }
    }
}