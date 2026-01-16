using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Plan.Response
{
    public class PlanResponseDTO
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MonthlyAnalysisLimit { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public int Status { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
