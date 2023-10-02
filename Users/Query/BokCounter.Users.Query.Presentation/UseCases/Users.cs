using BokCounter.Users.Query.Application.AppUsers.Queries;
using Carter;
using MediatR;

namespace BokCounter.Users.Query.Presentation.UseCases;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/Users")
            .WithTags("Users");

        group.MapGet("", async (
                ISender sender)
            => TypedResults.Ok(
                await sender.Send(new GetAppUsers.Query())));
    }
}
