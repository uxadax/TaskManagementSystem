using TaskManagementSystem.DataAccess;

namespace TaskManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManagementSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;  // Automatische Migrationen aktivieren
        }

        protected override void Seed(AppDbContext context)
        {
            // Standardbenutzer hinzufügen, falls keiner existiert
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(
                    new User { Id = 1, Name = "Standard User" }
                );
                context.SaveChanges();
            }
        }
    }
}
