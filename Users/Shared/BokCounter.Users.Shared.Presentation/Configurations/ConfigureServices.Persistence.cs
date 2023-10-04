namespace BokCounter.Users.Shared.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }

    public static async Task<WebApplication> UsePersistenceServicesAsync(this WebApplication app)
    {
        return app;
    }
}
