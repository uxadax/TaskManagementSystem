using System.Data.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("TaskManagementDB")
        {
            // Optional: Diese Zeile initialisiert die Datenbank, falls sie nicht existiert.
            Database.SetInitializer<AppDbContext>(new CreateDatabaseIfNotExists<AppDbContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
