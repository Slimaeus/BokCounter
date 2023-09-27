using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BokCounter.Users.Query.Persistence;

public class AppDbContextInitializer
{
    private readonly AppDbContext _applicationDbContext;

    public AppDbContextInitializer(AppDbContext applicationDbContext)
        => _applicationDbContext = applicationDbContext;
    public async Task InitialiseAsync()
    {
        try
        {
            await _applicationDbContext.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Migration error");
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Seeding error");
        }
    }

    public Task TrySeedAsync()
    {
        return Task.CompletedTask;
    }
}