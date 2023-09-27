using BokCounter.Users.Command.Application.AppUsers.Commands;
using BokCounter.Users.Shared.Domain.Entities;
using Carter;
using MediatR;

namespace BokCounter.Users.Command.Presentation.UseCases;

public class UserEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/Users")
            .WithTags("Users");

        group.MapPost("", async (ISender sender, CreateAppUser.Command command) => TypedResults.Ok(await sender.Send(command)));
        group.MapPut("{id:guid}", async (ISender sender, Guid id, UpdateAppUser.Command command) => TypedResults.Ok(await sender.Send(command)));
        group.MapDelete("{id:guid}", async (ISender sender, Guid id) => TypedResults.Ok(await sender.Send(new DeleteAppUser.Command(new AppUserId(id)))));
    }
}
