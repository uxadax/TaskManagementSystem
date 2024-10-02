using System.Collections.Generic;
using System.Linq;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.DataAccess
{
    public class TaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository()
        {
            _context = new AppDbContext();
        }

        public List<Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public List<TaskViewModel> GetTaskViewModels()
        {
            return _context.Tasks.Select(t => new TaskViewModel
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreateDate = t.CreateDate,  // Verwende CreateDate anstelle von DueDate
                IsCompleted = t.IsCompleted,
                UserId = t.UserId,
                UserName = t.User.UserName  // Korrekte Referenz auf den Benutzernamen
            }).ToList();
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

        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
