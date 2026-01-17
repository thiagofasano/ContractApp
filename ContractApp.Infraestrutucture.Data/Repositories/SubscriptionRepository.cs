using ContractApp.Domain.Dtos.Subscription.Response;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Repositories
{
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        public Subscription GetByUserId(int userId)
        {
            using (var dataContext = new DataContext())
            {
                var subscription = dataContext.Set<Subscription>()
                    .FirstOrDefault(s => s.UserId == userId);

                if (subscription == null)
                {
                    return null;
                }

                return subscription;
            }
        }
    }
}
