﻿using AutoMapper;
using BokCounter.Users.Command.Persistence;
using BokCounter.Users.Shared.Domain.Entities;
using BokCounter.Users.Shared.Domain.Events;
using MassTransit;
using MediatR;

namespace BokCounter.Users.Command.Application.AppUsers.Commands;

public static class UpdateAppUser
{
    public sealed record Command(AppUserId Id, AppIdentityUserId AppIdentityUserId) : IRequest<Unit>;
    public sealed record Request(AppUserId Id, AppIdentityUserId AppIdentityUserId);
    public sealed class Handler : IRequestHandler<Command, Unit>
    {
        private readonly IMongoDbContext _mongoDbContext;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public Handler(IMongoDbContext mongoDbContext, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mongoDbContext = mongoDbContext;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var appUser = _mapper.Map<AppUser>(request);
            var @event = new AppUserUpdatedEvent
            {
                Data = appUser
            };

            await _mongoDbContext.AppUserUpdatedEvents
                .InsertOneAsync(@event, cancellationToken: cancellationToken);

            await _publishEndpoint.Publish(@event).ConfigureAwait(false);

            return Unit.Value;
        }
    }
}
