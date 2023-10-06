using BokCounter.Users.Shared.Application.AppUsers.Commands;
using BokCounter.Users.Shared.Application.AppUsers.Dtos;
using BokCounter.Users.Shared.Domain.Entities;
using Carter;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;

namespace BokCounter.Users.Shared.Presentation.UseCases;

public class Users : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v1/Users");

        group.MapGet("", Get);
        group.MapPost("", Create);
        group.MapPut("{id:guid}", Update);
        group.MapDelete("{id:guid}", Delete);
    }
    private static async Task<Ok<IEnumerable<AppUserDto>>> Get(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient("QueryUsers");
        var result = await client.GetAsync("api/v1/Users");
        var content = await result.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<IEnumerable<AppUserDto>>(content, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return TypedResults.Ok(users);
    }
    private static async Task<Ok<AppUserId>> Create(IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient("CommandUsers");
        var result = await client.PostAsJsonAsync("api/v1/Users", new { });
        var content = await result.Content.ReadAsStringAsync();
        var userId = JsonSerializer.Deserialize<AppUserId>(content, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return TypedResults.Ok(userId);
    }
    private static async Task<NoContent> Update(IHttpClientFactory httpClientFactory, Guid id, UpdateAppUser.Request request)
    {
        var client = httpClientFactory.CreateClient("CommandUsers");
        await client.PutAsJsonAsync($"api/v1/Users/{id}", request);
        return TypedResults.NoContent();
    }
    private static async Task<NoContent> Delete(IHttpClientFactory httpClientFactory, Guid id)
    {
        var client = httpClientFactory.CreateClient("CommandUsers");
        await client.DeleteAsync($"api/v1/Users/{id}");
        return TypedResults.NoContent();
    }
}
