using BokCounter.Users.Query.Domain.Entities;

namespace BokCounter.Users.Query.Domain.Events;

public class AppUserDeletedEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public AppUserId Data { get; set; }
}
