using BokCounter.Users.Command.Persistence;
using BokCounter.Users.Command.Persistence.Settings;
using MongoDB.Driver;

namespace BokCounter.Users.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {

        var mongoDbSettings = configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>()
            ?? throw new InvalidOperationException();

        var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

        services.Configure<MongoDbSettings>(options =>
        {
            options.ConnectionString = mongoDbSettings.ConnectionString;
            options.DatabaseName = mongoDbSettings.DatabaseName;
        });

        services.AddSingleton<IMongoClient>(mongoClient);

        services.AddScoped<IMongoDbContext, MongoDbContext>();

        return services;
    }

    public static Task<WebApplication> UsePersistenceServicesAsync(this WebApplication app)
    {
        return Task.FromResult(app);
    }
}
