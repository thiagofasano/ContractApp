using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Domain.Entities
{
    public class AnalysisDownload
    {
        public int Id { get; set; } = 0;
        public Guid Guid { get; set; } = Guid.NewGuid();
        public int AnalysisId {  get; set; } = 0;
        public DateTime DownloadedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation Properties
        public Analysis? Analyse { get; set; }
    }
}
