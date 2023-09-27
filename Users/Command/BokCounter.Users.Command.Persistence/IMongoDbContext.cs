using BokCounter.Users.Shared.Domain.Events;
using MongoDB.Driver;

namespace BokCounter.Users.Command.Persistence;
public interface IMongoDbContext
{
    IMongoCollection<AppUserCreatedEvent> AppUserCreatedEvents { get; }
    IMongoCollection<AppUserUpdatedEvent> AppUserUpdatedEvents { get; }
    IMongoCollection<AppUserDeletedEvent> AppUserDeletedEvents { get; }
    IMongoDatabase Database { get; }
}