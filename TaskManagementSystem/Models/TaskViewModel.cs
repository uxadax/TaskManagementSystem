using System;

namespace TaskManagementSystem.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
