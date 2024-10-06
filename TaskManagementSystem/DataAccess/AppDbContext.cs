using System.Data.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("TaskManagementDB") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}
