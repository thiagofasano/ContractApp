using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class SubscriptionAnalysisUsageMap : IEntityTypeConfiguration<SubscriptionAnalysisUsage>
    {
        public void Configure(EntityTypeBuilder<SubscriptionAnalysisUsage> builder)
        {
            // Nome da tabela
            builder.ToTable("SubscriptionAnalysisUsage");

            // Chave primária
            builder.HasKey(uau => uau.Id);

            // Propriedades
            builder.Property(uau => uau.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(uau => uau.SubscriptionId).HasColumnName("SubscriptionId").IsRequired();
            builder.Property(uau => uau.Year).HasColumnName("Year");
            builder.Property(uau => uau.Month).HasColumnName("Month");
            builder.Property(uau => uau.AnalysisCount).HasColumnName("AnalysisCount");
            builder.Property(uau => uau.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(uau => uau.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(uau => uau.Subscription)
                     .WithMany(p => p.UserAnalysisUsages)
                     .HasForeignKey(uau => uau.SubscriptionId);
        }
    }
}
