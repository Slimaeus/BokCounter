using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Shared.Application.AppUsers.Commands;

public static class UpdateAppUser
{
    public sealed record Request(AppUserId Id, AppIdentityUserId AppIdentityUserId);
}
