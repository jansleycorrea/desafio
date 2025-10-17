using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Infrastructure.EntitiesConfiguration
{
    public class FavoriteListConfiguration : IEntityTypeConfiguration<FavoriteList>
    {
        public void Configure(EntityTypeBuilder<FavoriteList> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(256).IsRequired();
            builder.Property(p => p.Default).IsRequired();

            builder.HasOne(f => f.Client).WithMany(f => f.FavoriteLists).HasForeignKey(f => f.ClientId);
        }
    }
}
