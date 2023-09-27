using BokCounter.Users.Command.Domain.Entities;

namespace BokCounter.Users.Command.Domain.Events;

public class AppUserUpdatedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUser? Data { get; set; }
}
