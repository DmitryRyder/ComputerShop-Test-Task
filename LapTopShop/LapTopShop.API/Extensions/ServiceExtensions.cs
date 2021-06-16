using System.Collections.Generic;
using LapTopShop.DAL.Repositories.Implementations;
using LapTopShop.DAL.Repositories.Interfaces;
using LapTopShop.Models.DataModels;
using LapTopShop.Service.CommandHandlers;
using LapTopShop.Service.Commands;
using LapTopShop.Service.Queries;
using LapTopShop.Service.QueryHandlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LapTopShop.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterRepositoies(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILaptopRepository), typeof(LaptopRepository));
            services.AddScoped(typeof(IConfigurationRepository), typeof(ConfigurationRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IRequestHandler<GetLaptopsQuery, List<Laptop>>, GetLaptopsQueryHandler>();
            services.AddTransient<IRequestHandler<CreateLaptopCommand, Laptop>, CreateLaptopCommandHandler>();
            services.AddTransient<IRequestHandler<CreateConfigurationCommand, Configuration>, CreateConfigurationCommandHandler>();
            services.AddTransient<IRequestHandler<GetConfigurationsQuery, List<Configuration>>, GetConfigurationsQueryHandler>();
            services.AddTransient<IRequestHandler<GetConfigurationTypesQuery, List<ConfigurationType>>, GetConfigurationTypesQueryHandler>();
            services.AddTransient<IRequestHandler<CreateOrderCommand, Order>, CreateOrderCommandHandler>();
        }
    }
}
