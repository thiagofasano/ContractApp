using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class SubscriptionAnalysisUsage
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int SubscriptionId { get; set; } = 0;
        public string Year { get; set; } = string.Empty;
        public string Month { get; set; } = string.Empty;
        public int AnalysisCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();

        // Navigation Properties
        public Subscription? Subscription { get; set; }
    }
}
