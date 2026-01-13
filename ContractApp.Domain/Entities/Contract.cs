using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class Contract
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int UserId { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public int AlertExpirationDateInDays { get; set; } = 0;
        public List<string> AlertExpirationRecipients { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public User? User { get; set; }
        public List<Analysis>? Analyses { get; set; }
    }
}
