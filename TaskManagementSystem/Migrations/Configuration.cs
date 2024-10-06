using System.Data.Entity.Migrations;
using System.Linq;
using TaskManagementSystem.DataAccess;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(
                    new User { Id = 1, UserName = "Standard User" }  // Korrekte Eigenschaft verwenden
                );
                context.SaveChanges();
            }
        }
    }
}
