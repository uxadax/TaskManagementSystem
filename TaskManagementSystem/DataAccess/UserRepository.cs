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

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.Id);  // User suchen
            if (existingUser != null)
            {
                _context.Entry(existingUser).CurrentValues.SetValues(user);  // Werte aktualisieren
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
