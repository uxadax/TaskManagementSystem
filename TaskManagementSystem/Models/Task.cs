namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime CreateDate { get; set; }
        public bool IsCompleted { get; set; }

        // Der UserId bleibt als int, damit wir die Beziehung herstellen können.
        public int UserId { get; set; }

        // Dies ist die Navigationseigenschaft für die Beziehung
        public User User { get; set; }
    }
}
