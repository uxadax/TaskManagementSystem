using TaskManagementSystem.DataAccess;

namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppDbContext context)
        {
            // Hier können Seed-Daten hinzugefügt werden, wenn notwendig
        }
    }
}
