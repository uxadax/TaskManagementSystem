using System.Data.Entity;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Definieren der Beziehung zwischen Task und User
            modelBuilder.Entity<Task>()
                .HasRequired(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
