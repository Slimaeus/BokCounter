using BokCounter.Users.Query.Persistence;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;

namespace BokCounter.Users.Query.Infrastructure.AppUsers.Consumers;

public class AppUserCreatedEventConsumer : IConsumer<AppUserCreatedEvent>
{
    private readonly AppDbContext _appDbContext;

    public AppUserCreatedEventConsumer(AppDbContext appDbContext)
        => _appDbContext = appDbContext;
    public async Task Consume(ConsumeContext<AppUserCreatedEvent> context)
    {
        if (context.Message.Data == null) return;

        await _appDbContext.AddAsync(context.Message.Data);

        await _appDbContext.SaveChangesAsync();
    }
}
