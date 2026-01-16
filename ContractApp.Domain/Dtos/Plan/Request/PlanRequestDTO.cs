using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Dtos.Plan.Request
{
    public class PlanRequestDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MonthlyAnalysisLimit { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public int Status { get; set; } = 0;
    }
}
