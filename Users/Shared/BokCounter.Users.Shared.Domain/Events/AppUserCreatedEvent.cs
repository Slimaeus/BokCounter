using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Shared.Domain.Events;

public class AppUserCreatedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUser? Data { get; set; }
}
