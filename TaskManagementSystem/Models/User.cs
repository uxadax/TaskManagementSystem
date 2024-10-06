using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }  // Eindeutige ID für jeden Benutzer
        public string UserName { get; set; }  // Korrekte Benennung der Benutzereigenschaft
        public ICollection<Task> Tasks { get; set; }
    }
}
