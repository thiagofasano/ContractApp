using ContractApp.Domain.Dtos.Subscription.Request;
using ContractApp.Domain.Dtos.Subscription.Response;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface ISubscriptionService
    {
        void AddFree(int planId, int userId);
        void UpgradeDowngrade(SubscriptionUpDownGradeRequestDTO request);
        void Renew(int subscriptionId);
        Subscription GetById(int id);
        Subscription GetByUserId(int userId);
        
    }
}
