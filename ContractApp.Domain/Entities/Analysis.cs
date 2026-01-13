using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class Analysis
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int ContractId { get; set; } = 0;
        public string Summary { get; set; } = string.Empty;
        public string AbusiveClauses { get; set; } = string.Empty;
        public string Improvements { get; set; } = string.Empty;
        public string LegalRefs { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Property
        public Contract? Contract { get; set; }
        public List<AnalysisDownload>? AnalysisDownload { get; set; }
    }
}
