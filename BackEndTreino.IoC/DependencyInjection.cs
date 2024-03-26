using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Context;
using BackEndTreino.ReposImpl;
using BackEndTreino.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndTreino.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BackEndTreino")));

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IBrandRepo, BrandRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();

            return services;
        }
    }
}