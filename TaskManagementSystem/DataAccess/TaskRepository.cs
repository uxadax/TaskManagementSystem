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

        // Neue Methode für das TaskViewModel, um Daten im DataGridView anzuzeigen
        public List<TaskViewModel> GetTaskViewModels()
        {
            return _context.Tasks.Select(t => new TaskViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted,
                UserId = t.UserId,
                UserName = t.User.Name  // Hier wird der Name des Benutzers angezeigt
            }).ToList();
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            var existingTask = _context.Tasks.Find(task.Id);  // Task suchen
            if (existingTask != null)
            {
                _context.Entry(existingTask).CurrentValues.SetValues(task);  // Werte aktualisieren
                _context.SaveChanges();
            }
        }

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
