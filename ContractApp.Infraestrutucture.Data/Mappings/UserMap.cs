using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Nome da Tabela
            builder.ToTable("Users");

            // Chave Primária
            builder.HasKey(u => u.Id);

            // Propriedades
            builder.Property(u => u.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.DocumentType).HasColumnName("DocumentType");
            builder.Property(u => u.DocumentPerson).HasColumnName("DocumentPerson");
            builder.Property(u => u.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(u => u.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasMany(u => u.UserAddress)
                   .WithOne(ua => ua.User)
                   .HasForeignKey(u => u.UserId);

            builder.HasMany(u => u.Contracts)
                .WithOne(ua => ua.User)
                .HasForeignKey(u => u.UserId);

            builder.HasMany(u => u.Subscriptions)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
        }
    }
}
