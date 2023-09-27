namespace BokCounter.Users.Query.Domain.Entities;

public class AppUser
{
    public AppUserId Id { get; set; } = AppUserId.New();
    public AppIdentityUserId AppIdentityUserId { get; set; }
}
