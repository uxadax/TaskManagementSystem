using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property für Aufgaben
        public ICollection<Task> Tasks { get; set; }
    }
}
