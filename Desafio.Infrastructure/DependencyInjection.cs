using System;
using Desafio.Infrastructure.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Desafio.Domain.Interfaces;
using Desafio.Infrastructure.Repositories;
using Desafio.Application.Interfaces;
using Desafio.Application.Services;
using Desafio.Domain.Account;
using Desafio.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Http;

namespace Desafio.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? configuration["ConnectionStrings:DefaultConnection"];
            var baseUrlApi = configuration["UrlApi"];

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrada. Verifique appsettings.json ou variáveis de ambiente.");
            }

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString, npgsqlOptions =>
                    npgsqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.GetName().Name)
                )
            );

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddHttpClient("ApiClient", client =>
            {
                if(string.IsNullOrWhiteSpace(baseUrlApi))
                {
                    throw new InvalidOperationException("Base URL da API não encontrada. Verifique appsettings.json ou variáveis de ambiente.");
                }
                client.BaseAddress = new Uri(baseUrlApi);
            });

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IFavoriteListRepository, FavoriteListRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IFavoriteListService, FavoriteListService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            return services;
        }
    }
}
