using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class ContractMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            // Nome da Tabela
            builder.ToTable("Contracts");

            // Chave Primária
            builder.HasKey(c => c.Id);

            // Propriedades
            builder.Property(c => c.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(c => c.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(c => c.Title).HasColumnName("Title").IsRequired();
            builder.Property(c => c.Description).HasColumnName("Description");
            builder.Property(c => c.FileUrl).HasColumnName("FileUrl");
            builder.Property(c => c.ExpirationDate).HasColumnName("ExpirationDate");
            builder.Property(c => c.AlertExpirationDateInDays).HasColumnName("AlertExpirationInDays");
            builder.Property(c => c.AlertExpirationRecipients).HasColumnName("AlertExpirationRecipients");
            builder.Property(c => c.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(c => c.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(c => c.User)
                   .WithMany(u => u.Contracts)
                   .HasForeignKey(c => c.UserId);

            builder.HasMany(c => c.Analyses)
                   .WithOne(a => a.Contract)
                   .HasForeignKey(a => a.ContractId);

        }
    }
}
