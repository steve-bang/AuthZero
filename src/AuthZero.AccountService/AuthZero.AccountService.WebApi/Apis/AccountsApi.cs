

using System.Security.Claims;
using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.AccountService.Application.Features.Queries;
using AuthZero.AccountService.Application.Models;
using AuthZero.AccountService.Domain.AggregatesModel.User;



namespace AuthZero.AccountService.Apis;

public static class AccountsApi
{
    public static RouteGroupBuilder MapAccountsApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/accounts");

        // POST api/accounts/register
        api.MapPost("register", RegisterUserAsync);

        // POST api/accounts/login
        api.MapPost("login", LoginUserAsync);


        // GET api/accounts/{id}
        // If the id is me, it will return the current user id
        // Otherwise, it will return the user id by the id provided
        api.MapGet("{id}", GetUserByIdAsync).RequireAuthorization();

        return api;
    }

    public static async Task<Guid> RegisterUserAsync(
        RegisterUserCommand command, 
        [AsParameters] AccountService accountService)
    {
        var idNewUser = await accountService.Mediator.Send(command);

        return idNewUser;
    }

    public static async Task<ResultUserLoginSuccess> LoginUserAsync(
        LoginUserCommand command, 
        [AsParameters] AccountService accountService)
    {
        var result = await accountService.Mediator.Send(command);

        return result;
    }

    public static async Task<User?> GetUserByIdAsync(
        string id, 
        [AsParameters] AccountService accountService
    )
    {

        // If the id is me, it will return the current user id
        if (id == "me")
        {
            var user = accountService.HttpContextAccessor.HttpContext.User;

            id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        // Otherwise, it will return the user id by the id provided

        GetUserByIdQuery query = new(Guid.Parse(id));

        return await accountService.Mediator.Send(query);
    }
}