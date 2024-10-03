using System;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }  // Angepasst von DueDate auf CreateDate
        public bool IsCompleted { get; set; }

        // Fremdschlüssel für den Benutzer
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
