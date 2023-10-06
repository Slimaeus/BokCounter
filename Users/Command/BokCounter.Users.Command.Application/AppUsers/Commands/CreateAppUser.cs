using BokCounter.Users.Command.Persistence;
using BokCounter.Users.Shared.Domain.Entities;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;
using MediatR;

namespace BokCounter.Users.Command.Application.AppUsers.Commands;

public static class CreateAppUser
{
    public sealed record Command : IRequest<AppUserId>;
    public sealed record Request;
    public sealed class Handler : IRequestHandler<Command, AppUserId>
    {
        private readonly IMongoDbContext _mongoDbContext;
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IMongoDbContext mongoDbContext, IPublishEndpoint publishEndpoint)
        {
            _mongoDbContext = mongoDbContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<AppUserId> Handle(Command request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                AppIdentityUserId = AppIdentityUserId.New()
            };
            var @event = new AppUserCreatedEvent
            {
                Data = appUser
            };

            await _mongoDbContext.AppUserCreatedEvents
                .InsertOneAsync(@event, cancellationToken: cancellationToken);

            await _publishEndpoint.Publish(@event).ConfigureAwait(false);

            return appUser.Id;
        }
    }
}
