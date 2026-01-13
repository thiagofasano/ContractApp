using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class AnalysisMap : IEntityTypeConfiguration<Analysis>
    {
        public void Configure(EntityTypeBuilder<Analysis> builder)
        {
            // Nome da Tabela
            builder.ToTable("Analysis");

            // Chave Primária
            builder.HasKey(a => a.Id);

            // Propriedades
            builder.Property(a => a.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(a => a.ContractId).HasColumnName("ContractId").IsRequired();
            builder.Property(a => a.Summary).HasColumnName("Summary");
            builder.Property(a => a.AbusiveClauses).HasColumnName("AbusiveClauses");
            builder.Property(a => a.Improvements).HasColumnName("Improvements");
            builder.Property(a => a.LegalRefs).HasColumnName("LegalRefs");
            builder.Property(a => a.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(a => a.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(a => a.Contract)
                     .WithMany(c => c.Analyses)
                     .HasForeignKey(a => a.ContractId);

            builder.HasMany(a => a.AnalysisDownload)
                     .WithOne(ad => ad.Analyse)
                     .HasForeignKey(ad => ad.AnalysisId);
        }
    }
}
