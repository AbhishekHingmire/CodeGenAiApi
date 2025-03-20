using System.Collections.Generic;

namespace CodeGeneratorApi.Models
{
    public class User
    {
        public int Id { get; set; }

        // Nullable fields (safe for EF Core)
        public string? Username { get; set; }
        public string? Password { get; set; }

        public bool PaymentDone { get; set; } = false;

        // Navigation property
        public ICollection<ChatMessage>? ChatMessages { get; set; }
    }
}
