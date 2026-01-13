using ContractApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContractApp.Infra.Data.Mappings
{
    public class UserAddressMap : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            // Nome da Tabela
            builder.ToTable("UserAddresses");

            // Chave Primária
            builder.HasKey(ua => ua.Id);

            // Propriedades
            builder.Property(ua => ua.Guid).HasColumnName("Guid").IsRequired();
            builder.Property(ua => ua.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(ua => ua.Street).HasColumnName("Street");
            builder.Property(ua => ua.Number).HasColumnName("Number");
            builder.Property(ua => ua.City).HasColumnName("City");
            builder.Property(ua => ua.State).HasColumnName("State");
            builder.Property(ua => ua.Country).HasColumnName("Country");
            builder.Property(ua => ua.ZipCode).HasColumnName("ZipCode");
            builder.Property(ua => ua.CreatedAt).HasColumnName("CreatedAt");
            builder.Property(ua => ua.UpdatedAt).HasColumnName("UpdatedAt");

            // Relacionamentos
            builder.HasOne(u => u.User)
                   .WithMany(usr => usr.UserAddress)
                   .HasForeignKey(u => u.UserId);
        }
    }
}
