using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string DocumentType { get; set; } = string.Empty;
        public string DocumentPerson { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public List<Subscription>? Subscriptions { get; set; }
        public List<UserAddress>? UserAddress { get; set; }
        public List<Contract>? Contracts { get; set; }

    }
}
