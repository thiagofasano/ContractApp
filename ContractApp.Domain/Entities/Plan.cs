using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class Plan
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MonthlyAnalysisLimit { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public int Status { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = new DateTime();
        public DateTime UpdatedAt { get; set; } = new DateTime();

        // Navigation Property
        public List<Subscription>? Subscriptions { get; set; }

    }
}
