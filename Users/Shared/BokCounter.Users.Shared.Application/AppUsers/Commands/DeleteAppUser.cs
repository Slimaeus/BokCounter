using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Shared.Application.AppUsers.Commands;

public static class DeleteAppUser
{
    public sealed record Request(AppUserId Id);
}
