using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Subscription.Response
{
    public class SubscriptionResponseDTO
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
    }
}
