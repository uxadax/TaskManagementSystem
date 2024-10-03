using TaskManagementSystem.DataAccess;

namespace TaskManagementSystem.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TaskManagementSystem.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            // Beispielbenutzer hinzufügen
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(new User { Id = 1, UserName = "Admin" });
                context.SaveChanges();
            }
        }
    }
}
