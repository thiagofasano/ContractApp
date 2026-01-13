using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
    {
        public void Configure(EntityTypeBuilder<Subscription> builder)
        {
            // Nome da Tabela
            builder.ToTable("Subscriptions");

            // Chave Primária
            builder.HasKey(s => s.Id);

            // Propriedades
            builder.Property(s => s.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.PlanId).HasColumnName("PlanId").IsRequired();
            builder.Property(s => s.StartDate).HasColumnName("StartDate");
            builder.Property(s => s.EndDate).HasColumnName("EndDate");
            builder.Property(s => s.Status).HasColumnName("Status");
            builder.Property(s => s.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(s => s.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(s => s.User)
                   .WithMany(u => u.Subscriptions)
                   .HasForeignKey(s => s.UserId);

            builder.HasOne(s => s.Plan)
                .WithMany(p => p.Subscriptions)
                .HasForeignKey(s => s.PlanId);

            builder.HasMany(s => s.Payments)
                   .WithOne(p => p.Subscription)
                   .HasForeignKey(p => p.SubscriptionId);

            builder.HasMany(s => s.UserAnalysisUsages)
                     .WithOne(uau => uau.Subscription)
                     .HasForeignKey(uau => uau.SubscriptionId);
        }
    }
}
