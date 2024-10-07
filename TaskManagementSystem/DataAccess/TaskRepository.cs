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

        public List<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            var existingTask = _context.Tasks.Find(task.Id);
            if (existingTask != null)
            {
                _context.Entry(existingTask).CurrentValues.SetValues(task);
                _context.SaveChanges();
            }
        }

        // Verwenden Sie die Task-Instanz und nicht die ID für das Löschen.
        public void DeleteTask(Task task)
        {
            var existingTask = _context.Tasks.Find(task.Id);
            if (existingTask != null)
            {
                _context.Tasks.Remove(existingTask);
                _context.SaveChanges();
            }
        }
    }
}
