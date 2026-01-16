using ContractApp.Domain.Dtos.Plan.Request;
using ContractApp.Domain.Dtos.Plan.Response;
using ContractApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Interfaces.Services
{
    public interface IPlanService
    {
        List<PlanResponseDTO> GetAll();
        PlanResponseDTO GetById(int id);
        void Add(PlanRequestDTO request);
        void Update(int id, PlanRequestDTO request);
    }
}
