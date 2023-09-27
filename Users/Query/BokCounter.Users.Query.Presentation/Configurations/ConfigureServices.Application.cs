using FluentValidation;

namespace BokCounter.Users.Query.Presentation.Configurations;

public static partial class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssemblies(Application.AssemblyReference.Assembly);
        });
        services.AddAutoMapper(Application.AssemblyReference.Assembly);
        services.AddValidatorsFromAssembly(Application.AssemblyReference.Assembly);
        return services;
    }
}
