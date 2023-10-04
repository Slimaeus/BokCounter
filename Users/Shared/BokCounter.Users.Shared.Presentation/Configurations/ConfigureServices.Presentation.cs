using Carter;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

namespace BokCounter.Users.Shared.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var ocelotConfiguration = new ConfigurationBuilder()
            .AddJsonFile("ocelot.json")
            .Build();

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddOcelot(ocelotConfiguration);
        //services.AddSwaggerForOcelot(configuration);
        services.AddSwaggerGen(options =>
        {
            var securitySchema = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            options.AddSecurityDefinition("Bearer", securitySchema);

            var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

            options.AddSecurityRequirement(securityRequirement);

            options.CustomSchemaIds(type => type.FullName!.Replace("+", "."));
        });

        services.AddCarter();
        return services;
    }
    public static WebApplication UsePresentationServices(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            options.InjectStylesheet("/swagger/custom.css");
            options.EnableTryItOutByDefault();
        });
        //app.UseSwaggerForOcelotUI();

        const string CustomStyles = @"
            .swagger-ui .opblock .opblock-summary .view-line-link {
                margin: 0 5px;
                width: 24px;
            }";

        app.MapGet("/swagger/custom.css", () => Results.Text(CustomStyles, "text/css", Encoding.UTF8)).ExcludeFromDescription();

        app.MapCarter();

        app.UseHttpsRedirection();

        app.UseOcelot();

        return app;
    }
}
