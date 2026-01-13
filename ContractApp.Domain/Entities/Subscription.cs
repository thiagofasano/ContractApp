using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class Subscription
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int UserId { get; set; } = 0;
        public int PlanId { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddMonths(1);
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public User? User { get; set; }
        public Plan? Plan { get; set; }
        public List<Payment>? Payments { get; set; }
        public List<SubscriptionAnalysisUsage>? UserAnalysisUsages { get; set; }
    }
}
