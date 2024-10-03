using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        // Beziehung zu den Aufgaben
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
