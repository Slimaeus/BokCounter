namespace BokCounter.Users.Command.Domain.Entities;

public class AppUser
{
    public AppUserId Id { get; set; } = AppUserId.New();
    public AppIdentityUserId AppIdentityUserId { get; set; }
}
