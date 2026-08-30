using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using AqaTest.Interfaces.DapperInterfaces;
using AqaTest.Repositories;
using AqaTest.DTO.DapperDTO;

namespace AqaTest.Modules;

public static class DataAccessMarketplaceModule
{
    public static IServiceCollection AddDataAccessMarketplace(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IUserRepository>(p => new UserRepository(connectionString));
        services.AddScoped<IAddressRepository>(_ => new AddressRepository(connectionString));
        services.AddScoped<ICategoryRepository>(_ => new CategoryRepository(connectionString));
        services.AddScoped<IProductRepository>(_ => new ProductRepository(connectionString));
        services.AddScoped<IOrderRepository>(_ => new OrderRepository(connectionString));
        services.AddScoped<IOrderItemRepository>(_ => new OrderItemRepository(connectionString));
        return services;
    }
}