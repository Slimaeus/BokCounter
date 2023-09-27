using BokCounter.Users.Query.Domain.Entities;

namespace BokCounter.Users.Query.Domain.Events;

public class AppUserCreatedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUser? Data { get; set; }
}
