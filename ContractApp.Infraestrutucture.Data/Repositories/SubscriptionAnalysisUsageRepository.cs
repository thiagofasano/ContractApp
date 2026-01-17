using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Repositories
{
    public class SubscriptionAnalysisUsageRepository : BaseRepository<SubscriptionAnalysisUsage>, ISubscriptionAnalysisUsageRepository
    {
        public SubscriptionAnalysisUsage GetBySubscripitonId(int subscriptonId)
        {
            using (var dataContext = new DataContext())
            {
                var analysisUsage = dataContext.Set<SubscriptionAnalysisUsage>()
                        .FirstOrDefault(s => s.SubscriptionId == subscriptonId);
               
                if (analysisUsage == null)
                {
                    return null;
                }

                return analysisUsage;
            }
        }
    }
}
