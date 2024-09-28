﻿using System;

namespace TaskManagementSystem.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        // Foreign Key zu User
        public int UserId { get; set; }

        // Navigation Property (optional)
        public User User { get; set; }
    }
}
