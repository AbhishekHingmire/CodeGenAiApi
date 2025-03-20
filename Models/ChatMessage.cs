using System;

namespace CodeGeneratorApi.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property
        public User? User { get; set; }
    }
}
