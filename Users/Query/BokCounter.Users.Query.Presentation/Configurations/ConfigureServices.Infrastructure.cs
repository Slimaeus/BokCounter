using MassTransit;

namespace BokCounter.Users.Query.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(config =>
        {
            config.SetKebabCaseEndpointNameFormatter();

            config.AddConsumers(Infrastructure.AssemblyReference.Assembly);

            config.UsingRabbitMq((context, options) =>
            {
                options.Host(new Uri("amqp://localhost:5672"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                options.ConfigureEndpoints(context);
            });
        });

        return services;
    }
}
