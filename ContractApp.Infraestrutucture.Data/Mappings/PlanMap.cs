using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class PlanMap : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            // Nome da Tabela
            builder.ToTable("Plans");

            // Chave Primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.MonthlyAnalysisLimit).HasColumnName("MonthlyAnalysisLimit");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasMany(p => p.Subscriptions)
                .WithOne(s => s.Plan)
                .HasForeignKey(s => s.PlanId);
        }
    }
}
