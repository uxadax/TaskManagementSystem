using System;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }  // Korrigiert: Verwende CreateDate anstelle von DueDate
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
