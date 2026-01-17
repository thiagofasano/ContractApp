using ContractApp.Domain.Dtos.Subscription.Request;
using ContractApp.Domain.Dtos.Subscription.Response;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Services
{
    public class SubscriptionService (ISubscriptionRepository subscriptionRepository, IPlanService planService, ISubscriptionAnalysisUsageService subscriptionAnalysisUsageService) : ISubscriptionService
    {
        public void AddFree(int planId, int userId)
        {
            var plan = planService.GetById(planId);

            if (plan == null) {
                throw new Exception("Plano não encontrado");
            }

            // Plano Free
            if (plan.Name == "free") {
                var subscription = new Subscription
                {
                    UserId = userId,
                    PlanId = planId,
                    StartDate = DateTime.UtcNow,
                    EndDate = null,
                    Status = "active",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                subscriptionRepository.Add(subscription);
            }
        }

        public void UpgradeDowngrade(SubscriptionUpDownGradeRequestDTO request)
        {
            var activePlan = planService.GetById(request.ActivePlanId);

            if (activePlan == null) {
                throw new Exception("Plano ativo não encontrado");
            }

            if (request.NewPlanId == 0) {
                throw new Exception("Novo plano inválido");
            }

            var subscription = subscriptionRepository.GetById(request.SubscriptionId);

            if (subscription == null)
            {
                throw new Exception("Assinatura não encontrada para o plano ativo");
            }


            // Encerrar a assinatura ativa
            subscription.EndDate = DateTime.UtcNow;
            subscription.Status = "upgraded/downgrade";
            subscriptionRepository.Update(subscription);

            // Criar nova assinatura para o novo plano
            var newSubscription = new Subscription
            {
                UserId = subscription.UserId,
                PlanId = request.NewPlanId,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddMonths(1),
                Status = "active",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            subscriptionRepository.Add(newSubscription);

            // Criar novo Analisys Usage
            if (newSubscription == null)
            {
                throw new Exception(
                    "Nova assinatura não encontrada após upgrade/downgrade");
            }

            subscriptionAnalysisUsageService.Add(newSubscription.Id);
            }

        public void Renew(int subscriptionId)
        {
            var subscription = subscriptionRepository.GetById(subscriptionId);

            if (subscription == null)
            {
                throw new Exception("Assinatura não encontrada.");
            }
            if (subscription.EndDate == null)
            {
                throw new Exception("Assinatura não possui data de término definida");
            }

            // Renovar a assinatura adicionando mais um período (exemplo: 1 mês)
            subscription.EndDate = subscription.EndDate.Value.AddMonths(1);
            subscription.UpdatedAt = DateTime.UtcNow;
            subscriptionRepository.Update(subscription);

            // Adicionando SubscriptionAnalysisUsage para o período renovado
            subscriptionAnalysisUsageService.Add(subscription.Id);
        }

        public Subscription GetById(int id)
        {
            var subscription = subscriptionRepository.GetById(id);

            if (subscription == null)
            {
                throw new Exception("Assinatura não encontrada.");
            }

            return subscription;
        }

        public Subscription GetByUserId(int userId)
        {
            var subscription = subscriptionRepository.GetByUserId(userId);

            if (subscription == null)
            {
                throw new Exception("Assinatura não encontrada.");
            }

            return subscription;
        }

  
    }
}
