using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class TaskRepository
    {
        private AppDbContext _context;

        public TaskRepository()
        {
            _context = new AppDbContext();
        }

        // Methode zum Abrufen aller Tasks
        public List<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        // Methode zum Hinzufügen einer neuen Task
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        // Methode zum Aktualisieren einer bestehenden Task
        public void UpdateTask(Task task)
        {
            // Überprüfen, ob die Task vorhanden ist
            var existingTask = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                _context.Entry(existingTask).CurrentValues.SetValues(task);  // Werte aktualisieren
                _context.SaveChanges();
            }
        }

        // Methode zum Löschen einer Task
        public void DeleteTask(Task task)
        {
            // Lade die Task aus der Datenbank, um den aktuellen Zustand sicherzustellen
            var existingTask = _context.Tasks.SingleOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                _context.Tasks.Remove(existingTask);
                _context.SaveChanges();
            }
        }
    }
}
