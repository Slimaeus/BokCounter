using BokCounter.Users.Command.Persistence.Settings;
using BokCounter.Users.Shared.Domain.Events;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BokCounter.Users.Command.Persistence;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoClient _mongoClient;
    private readonly string _databaseName;

    public MongoDbContext(IMongoClient mongoClient, IOptions<MongoDbSettings> options)
    {
        _mongoClient = mongoClient;
        _databaseName = options.Value.DatabaseName;
    }

    public IMongoDatabase Database => _mongoClient.GetDatabase(_databaseName);

    public IMongoCollection<AppUserCreatedEvent> AppUserCreatedEvents => Database.GetCollection<AppUserCreatedEvent>(nameof(AppUserCreatedEvent));
    public IMongoCollection<AppUserUpdatedEvent> AppUserUpdatedEvents => Database.GetCollection<AppUserUpdatedEvent>(nameof(AppUserUpdatedEvent));
    public IMongoCollection<AppUserDeletedEvent> AppUserDeletedEvents => Database.GetCollection<AppUserDeletedEvent>(nameof(AppUserDeletedEvent));
}
