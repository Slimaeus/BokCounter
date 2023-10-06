using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Shared.Application.AppUsers.Dtos;

public sealed record AppUserDto(AppUserId Id, AppIdentityUserId AppIdentityUserId);
