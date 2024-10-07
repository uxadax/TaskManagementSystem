using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class UserRepository
    {
        private AppDbContext _context;

        public UserRepository()
        {
            _context = new AppDbContext();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Verwenden Sie die User-Instanz und nicht die ID für das Löschen.
        public void DeleteUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }
    }
}
