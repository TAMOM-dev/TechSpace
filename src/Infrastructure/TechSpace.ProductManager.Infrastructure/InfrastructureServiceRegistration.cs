using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechSpace.ProductManager.Application.Contracts.Infrastructure;
using TechSpace.ProductManager.Application.Models.Mail;
using TechSpace.ProductManager.Infrastructure.FileExport;
using TechSpace.ProductManager.Infrastructure.Mail;


namespace TechSpace.ProductManager.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<ICsvExporter, CsvExporter>();

        return services;
    }
}
