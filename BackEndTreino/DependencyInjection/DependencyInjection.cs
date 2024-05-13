using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEndTreino.Context;
using BackEndTreino.Data.ReposImpl;
using BackEndTreino.Domain.Repositories;
using BackEndTreino.Interfaces;
using BackEndTreino.Interfaces.Base;
using BackEndTreino.Mappings;
using BackEndTreino.ReposImpl;
using BackEndTreino.Repositories;
using BackEndTreino.Services;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Web.Http;
using Core.Interfaces;

namespace BackEndTreino.DependencyInjection
{
    public class DependencyInjection
    {
        public IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration configuration, HttpConfiguration httpConfig)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
            AddServices(services);
            AddAutoMapper(services);
            AddRedis(services, configuration);
            AddCors(services, httpConfig);

            return services;
        }

        private static void AddCors(IServiceCollection services, HttpConfiguration config)
        {
            services.AddCors(options =>
            options.AddPolicy(
                "CorsPolicy",
                policy =>
                    policy

                        .AllowAnyOrigin()
                        .WithMethods("GET", "POST", "PUT", "DELETE")
                        .AllowAnyHeader()
             )
            );
            config.EnableCors();
        }

        private void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToDTO));
        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IBrandRepo, BrandRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IBasketRepo, BasketRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<IDeliveryMethod, DeliveryMethodRepo>();
        } 

        private void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("BackEndTreino.Infra")));
        }

        private static void AddRedis(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConnectionMultiplexer>(provider =>
            {
                var redisConfig = configuration.GetConnectionString("Redis");
                var redisOptions = ConfigurationOptions.Parse(redisConfig);
                return ConnectionMultiplexer.Connect(redisOptions);
            });
        }
    }
}