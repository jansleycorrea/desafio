using System;
using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.Infrastructure.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.Property(x => x.Id);
            builder.Property(p => p.Title).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Category).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Image).HasMaxLength(256).IsRequired();

            //chave primária composta para evitar produtos duplicados na mesma lista de favoritos. 
            //Estou persistindo alguns dados do produto para evitar que sejam buscados em uma API externa toda vez que a lista de favoritos for carregada.
            //O preço não está sendo persistido, pois pode variar com o tempo e não é essencial para a funcionalidade de favoritos e pode gerar algum tipo de problema o usuário visualizar um preço antigo.
            //Pensei em usar o CQRS com um banco redis e persistir o produto apenas nesse banco redis, mas para não complicar muito o desafio optei por não fazer isso.
            builder.HasKey(p => new { p.Id, p.FavoriteListId });

            builder.HasOne(f => f.FavoriteList).WithMany(f => f.Products).HasForeignKey(f => f.FavoriteListId);
        }
    }
}
