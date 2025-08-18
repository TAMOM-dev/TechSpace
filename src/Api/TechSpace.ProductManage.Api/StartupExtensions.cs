using System;

namespace TechSpace.ProductManage.Api;

public static class StartupExtensions
{
    public static WebApplication ConfigurationServices(this WebApplication builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistenceServices(builder.Configuration);
        builder.Services.AddControllers();

        builder.Services.AddCors(options => options.AddPolicy(
            "open",
            policy => policy.WithOrigins(
                builder.Configuration["ApiUrl"] ?? "http://localhost:5000")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .SetIsOriginAllowed(origin => true)
        ));

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        
    }
}
