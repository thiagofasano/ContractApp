using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Services
{
    public class SubscriptionAnalysisUsageService(ISubscriptionAnalysisUsageRepository subscriptionAnalysisUsageRepository) : ISubscriptionAnalysisUsageService
    {
        public void Add(int subscriptonId)
        {
            var analysisUsage = new SubscriptionAnalysisUsage
            {
              SubscriptionId = subscriptonId,
              Month = DateTime.UtcNow.Month.ToString("D2"),
              Year = DateTime.UtcNow.Year.ToString(),
              AnalysisCount = 0,
              CreatedAt = DateTime.UtcNow,
              UpdatedAt = DateTime.UtcNow
            };

            subscriptionAnalysisUsageRepository.Add(analysisUsage);
        }

        public void Update(int subscriptonId)
        {
            var analysisUsage = subscriptionAnalysisUsageRepository.GetBySubscripitonId(subscriptonId);
            
            if (analysisUsage != null)
            {
                analysisUsage.AnalysisCount += 1;
                analysisUsage.UpdatedAt = DateTime.UtcNow;
                subscriptionAnalysisUsageRepository.Update(analysisUsage);
            }
        }
    }
}
