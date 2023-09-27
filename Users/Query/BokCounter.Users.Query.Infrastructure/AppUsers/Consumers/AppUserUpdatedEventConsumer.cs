using BokCounter.Users.Query.Persistence;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace BokCounter.Users.Query.Infrastructure.AppUsers.Consumers;

public class AppUserUpdatedEventConsumer : IConsumer<AppUserUpdatedEvent>
{
    private readonly AppDbContext _appDbContext;

    public AppUserUpdatedEventConsumer(AppDbContext appDbContext)
        => _appDbContext = appDbContext;
    public async Task Consume(ConsumeContext<AppUserUpdatedEvent> context)
    {
        if (context.Message.Data == null) return;

        await _appDbContext.AppUsers
            .Where(x => x.Id == context.Message.Data.Id)
            .ExecuteUpdateAsync(x => x.SetProperty(
                a => a.AppIdentityUserId,
                a => context.Message.Data.AppIdentityUserId));
    }
}
