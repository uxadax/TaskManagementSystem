using System.Data.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext() : base("TaskManagementDB")
        {
        }
    }
}
