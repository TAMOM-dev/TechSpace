using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechSpace.ProductManager.Application.Contracts;
using TechSpace.ProductManager.Persistence.Repositories;

namespace TechSpace.ProductManager.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TechSpaceDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("TechSpaceProductManagerStringConnection")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();

        return services;
    }
}
