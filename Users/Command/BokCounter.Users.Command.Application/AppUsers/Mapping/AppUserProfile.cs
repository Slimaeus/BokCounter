using AutoMapper;
using BokCounter.Users.Command.Application.AppUsers.Commands;
using BokCounter.Users.Command.Application.AppUsers.Dtos;
using BokCounter.Users.Shared.Domain.Entities;

namespace BokCounter.Users.Command.Application.AppUsers.Mapping;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, AppUserDto>();
        CreateMap<CreateAppUser.Request, CreateAppUser.Command>();
        CreateMap<CreateAppUser.Command, AppUser>();
        CreateMap<UpdateAppUser.Request, UpdateAppUser.Command>();
        CreateMap<UpdateAppUser.Command, AppUser>();
        CreateMap<DeleteAppUser.Request, DeleteAppUser.Command>();
    }
}
