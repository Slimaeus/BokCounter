using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Shared.Domain.Events;

public class AppUserDeletedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUserId Data { get; set; }
}
