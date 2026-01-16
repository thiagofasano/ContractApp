using ContractApp.Domain.Dtos.Plan.Request;
using ContractApp.Domain.Dtos.Plan.Response;
using ContractApp.Domain.Entities;
using ContractApp.Domain.Interfaces.Repositories;
using ContractApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Services
{
    public class PlanService (IPlanRepository planRepository): IPlanService
    {
        public void Add(PlanRequestDTO request)
        {
            var plan = new Plan
            {
                Name = request.Name,
                Description = request.Description,
                MonthlyAnalysisLimit = request.MonthlyAnalysisLimit,
                Price = request.Price,
                Status = request.Status
            };

            planRepository.Add(plan);
        }

        public List<PlanResponseDTO> GetAll()
        {
            var plans = planRepository.GetAll();
            var planDTOs = new List<PlanResponseDTO>();

            foreach (var planDTO in plans) {
                planDTOs.Add(new PlanResponseDTO
                {
                    Id = planDTO.Id,
                    Guid = planDTO.Guid,
                    Name = planDTO.Name,
                    Description = planDTO.Description,
                    MonthlyAnalysisLimit = planDTO.MonthlyAnalysisLimit,
                    Price = planDTO.Price,
                    Status = planDTO.Status,
                    CreatedAt = planDTO.CreatedAt,
                    UpdatedAt = planDTO.UpdatedAt
                });
            }

            return planDTOs;
        }

        public PlanResponseDTO GetById(int id)
        {
            var plan = planRepository.GetById(id);
            
            if (plan == null)
            {
                throw new Exception("Plan not found.");
            }

            var planDTO = new PlanResponseDTO
            {
                Id = plan.Id,
                Guid = plan.Guid,
                Name = plan.Name,
                Description = plan.Description,
                MonthlyAnalysisLimit = plan.MonthlyAnalysisLimit,
                Price = plan.Price,
                Status = plan.Status,
                CreatedAt = plan.CreatedAt,
                UpdatedAt = plan.UpdatedAt
            };

            return planDTO;
        }

        public void Update(int id, PlanRequestDTO request)
        {
            var plan = planRepository.GetById(id);

            if(plan == null)
            {
                throw new Exception("Plan not found.");
            }

            plan.Description = request.Description;
            plan.MonthlyAnalysisLimit = request.MonthlyAnalysisLimit;
            plan.Price = request.Price;
            plan.Status = request.Status;
            plan.UpdatedAt = DateTime.UtcNow;

            planRepository.Update(plan);

        }
    }
}
