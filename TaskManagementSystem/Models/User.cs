using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        // Navigationseigenschaft
        public ICollection<Task> Tasks { get; set; }

        // Überschreibe die ToString-Methode, um den richtigen Namen anzuzeigen
        public override string ToString()
        {
            return UserName;
        }
    }
}
