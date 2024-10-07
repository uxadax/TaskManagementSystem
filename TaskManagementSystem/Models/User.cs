using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }  // Achten Sie darauf, dass UserName korrekt verwendet wird.

        // Dies ist die Navigationseigenschaft, um die Beziehung zu Tasks anzuzeigen
        public ICollection<Task> Tasks { get; set; }
    }
}
