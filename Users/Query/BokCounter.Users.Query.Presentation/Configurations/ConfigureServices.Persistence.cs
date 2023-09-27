using BokCounter.Users.Query.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BokCounter.Users.Query.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<AppDbContext>(options =>
        {
            options.UseSqlite("DataSource=BokCounterUser.db");
        });

        services.AddScoped<AppDbContextInitializer>();

        return services;
    }

    public static async Task<WebApplication> UsePersistenceServicesAsync(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            using var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
            await initializer.InitialiseAsync();
            await initializer.SeedAsync();
        }

        return app;
    }
}
