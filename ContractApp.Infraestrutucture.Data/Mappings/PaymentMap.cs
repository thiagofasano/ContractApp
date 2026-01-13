using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class PaymentMap : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Nome da tabela
            builder.ToTable("Payments");

            // Chave primária
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(p => p.SubscriptionId).HasColumnName("SubscriptionId").IsRequired();
            builder.Property(p => p.ExternalPaymentId).HasColumnName("ExternalPaymentId");
            builder.Property(p => p.Amount).HasColumnName("Amount").IsRequired();
            builder.Property(p => p.Currency).HasColumnName("Currency").IsRequired();
            builder.Property(p => p.PaymentMethod).HasColumnName("PaymentMethod").IsRequired();
            builder.Property(p => p.PaymentToken).HasColumnName("PaymentToken").IsRequired();
            builder.Property(p => p.ErrorMessage).HasColumnName("ErrorMessage");
            builder.Property(p => p.WebhookData).HasColumnName("WebhookData");
            builder.Property(p => p.PaidAt).HasColumnName("PaidAt");
            builder.Property(p => p.Status).HasColumnName("Status").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(p => p.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(p => p.Subscription)
                     .WithMany(s => s.Payments)
                     .HasForeignKey(p => p.SubscriptionId);

        }
    }
}
