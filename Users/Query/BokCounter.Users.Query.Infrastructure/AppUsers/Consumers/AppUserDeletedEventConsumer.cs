using BokCounter.Users.Query.Persistence;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace BokCounter.Users.Query.Infrastructure.AppUsers.Consumers;

public class AppUserDeletedEventConsumer : IConsumer<AppUserDeletedEvent>
{
    private readonly AppDbContext _appDbContext;

    public AppUserDeletedEventConsumer(AppDbContext appDbContext)
        => _appDbContext = appDbContext;
    public async Task Consume(ConsumeContext<AppUserDeletedEvent> context)
    {
        await _appDbContext.AppUsers
            .Where(x => x.Id == context.Message.Data)
            .ExecuteDeleteAsync();
    }
}
