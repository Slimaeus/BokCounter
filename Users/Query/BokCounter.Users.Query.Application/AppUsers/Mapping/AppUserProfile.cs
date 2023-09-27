using AutoMapper;
using BokCounter.Users.Query.Application.AppUsers.Dtos;
using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Query.Application.AppUsers.Mapping;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserDto>();
    }
}
