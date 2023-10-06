using BokCounter.Users.Command.Persistence;
using BokCounter.Users.Shared.Domain.Entities;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;
using MediatR;

namespace BokCounter.Users.Command.Application.AppUsers.Commands;

public static class DeleteAppUser
{
    public sealed record Command(AppUserId Id) : IRequest<Unit>;
    public sealed record Request(AppUserId Id);
    public sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IMongoDbContext _mongoDbContext;
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IMongoDbContext mongoDbContext, IPublishEndpoint publishEndpoint)
        {
            _mongoDbContext = mongoDbContext;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var @event = new AppUserDeletedEvent
            {
                Data = request.Id
            };

            await _mongoDbContext.AppUserDeletedEvents
                .InsertOneAsync(@event, cancellationToken: cancellationToken);

            await _publishEndpoint.Publish(@event).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
