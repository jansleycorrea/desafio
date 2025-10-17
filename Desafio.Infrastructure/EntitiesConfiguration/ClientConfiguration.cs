using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Desafio.Infrastructure.EntitiesConfiguration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(256).IsRequired().HasColumnType("VARCHAR(256) UNIQUE");
            builder.Property(p => p.Phone).HasMaxLength(20);
            builder.Property(p => p.Cpf).HasMaxLength(11);
            builder.Property(p => p.Cep).HasMaxLength(8);
            builder.Property(p => p.Address).HasMaxLength(256);
            builder.Property(p => p.AddressNumber).HasMaxLength(10);
            builder.Property(p => p.Active).IsRequired();
        }
    }
}
