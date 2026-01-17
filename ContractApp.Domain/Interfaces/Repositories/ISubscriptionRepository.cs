using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Repositories
{
    public interface ISubscriptionRepository : IBaseRepository<Subscription>
    {
        Subscription GetByUserId(int userId);
    }
}
