using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechSpace.ProductManager.Identity.Models;

namespace TechSpace.ProductManager.Identity;

public static class IdentityServiceExtensions
{
    public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

        services.AddAuthorizationBuilder();

        services.AddDbContext<TechSpaceIdentityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("TechSpaceIdentityConnectionString")));

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<TechSpaceIdentityDbContext>()
            .AddApiEndpoints();
    }
}
