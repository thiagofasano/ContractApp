using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Contract.Request
{
    public class ContractRequestDTO
    {
        public int UserId { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; } = DateTime.Now;
        public int AlertExpirationDateInDays { get; set; } = 0;
        public List<string> AlertExpirationRecipients { get; set; } = new List<string>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
