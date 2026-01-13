using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int SubscriptionId { get; set; } = 0;
        public int ExternalPaymentId { get; set; } = 0;
        public decimal Amount { get; set; } = 0.0m;
        public string Currency { get; set; } = "BRL";
        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentToken { get; set; } = string.Empty;
        public string ErrorMessage { get; set; } = string.Empty;
        public string WebhookData { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PaidAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public Subscription? Subscription { get; set; }
    }
}
