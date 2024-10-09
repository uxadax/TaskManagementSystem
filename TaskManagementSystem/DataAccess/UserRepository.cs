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

        // Löschen des Benutzers mit SingleOrDefault
        public void DeleteUser(User user)
        {
            // Verwende SingleOrDefault statt Find, um sicherzustellen, dass das Benutzerobjekt aus dem aktuellen Kontext kommt.
            var existingUser = _context.Users.SingleOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }

        // Alternativer Ansatz mit Übergabe der Benutzer-ID statt des gesamten Objekts.
        public void DeleteUserById(int userId)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }
    }
}
