using System;
using Scalar.AspNetCore;
using TechSpace.ProductManager.Application;
using TechSpace.ProductManager.Infrastructure;
using TechSpace.ProductManager.Persistence;

namespace TechSpace.ProductsManage.Api;

public static class StartupExtensions
{
        public static WebApplication ConfigureServices(
           this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddControllers();


            builder.Services.AddCors(options => options.AddPolicy(
                "open",
                policy => policy.WithOrigins(
                    builder.Configuration["ApiUrl"] ?? "https://localhost:5000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed(origin => true)
            ));

        // Optional: Enable Swagger for API documentation
        // builder.Services.AddSwaggerGen();
            builder.Services.AddOpenApi();
            
            


            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }
}
