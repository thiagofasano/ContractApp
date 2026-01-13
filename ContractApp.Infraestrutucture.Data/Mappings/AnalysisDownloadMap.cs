using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class AnalysisDownloadMap : IEntityTypeConfiguration<AnalysisDownload>
    {
        public void Configure(EntityTypeBuilder<AnalysisDownload> builder)
        {
            // Nome da Tabela
            builder.ToTable("AnalysisDownloads");

            // Chave Primária
            builder.HasKey(x => x.Id);

            // Propriedades
            builder.Property(x => x.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(x => x.AnalysisId).HasColumnName("AnalysisId").IsRequired();
            builder.Property(x => x.DownloadedAt).HasColumnName("DownloadedAt");
            builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(x => x.UpdatedAt).HasColumnName("UpdatedAt");


            // Relacionamentos
            builder.HasOne(x => x.Analyse)
                     .WithMany(a => a.AnalysisDownload)
                     .HasForeignKey(x => x.AnalysisId);
        }
    }
}
