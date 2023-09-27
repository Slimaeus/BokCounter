using BokCounter.Users.Command.Domain.Entities;

namespace BokCounter.Users.Command.Domain.Events;

public class AppUserDeletedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUserId Data { get; set; }
}
