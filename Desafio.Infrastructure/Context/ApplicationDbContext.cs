using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Desafio.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Desafio.Infrastructure.Identity;

namespace Desafio.Infrastructure.Context
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<FavoriteList> FavoriteList { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Ignore<Product>();
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //builder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
