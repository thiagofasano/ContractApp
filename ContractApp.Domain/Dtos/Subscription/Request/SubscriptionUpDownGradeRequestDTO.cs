using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Subscription.Request
{
    public class SubscriptionUpDownGradeRequestDTO
    {
        public int SubscriptionId { get; set; } = 0;
        public int ActivePlanId { get; set; } = 0;
        public int NewPlanId { get; set; } = 0;
}
}
