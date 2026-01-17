using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Subscription.Request
{
    public class SubscriptionRequestDTO
    {
        public int UserId { get; set; } = 0;
        public int PlanId { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
