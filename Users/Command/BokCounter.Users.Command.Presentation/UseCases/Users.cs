using AutoMapper;
using BokCounter.Users.Command.Application.AppUsers.Commands;
using BokCounter.Users.Shared.Domain.Entities;
using Carter;
using MediatR;

namespace BokCounter.Users.Command.Presentation.UseCases;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/Users")
            .WithTags("Users");

        group.MapPost("", async (
                ISender sender,
                IMapper mapper,
                CreateAppUser.Request request)
            => TypedResults.Ok(
                    await sender.Send(
                        mapper.Map<CreateAppUser.Command>(request))));

        group.MapPut("{id:guid}", async (
                ISender sender,
                IMapper mapper,
                Guid id,
                UpdateAppUser.Request request)
            => TypedResults.Ok(
                    await sender.Send(
                        mapper.Map<UpdateAppUser.Command>(request))));

        group.MapDelete("{id:guid}", async (
                ISender sender,
                IMapper mapper,
                Guid id)
            => TypedResults.Ok(
                    await sender.Send(
                        new DeleteAppUser.Command(new AppUserId(id)))));
    }
}
