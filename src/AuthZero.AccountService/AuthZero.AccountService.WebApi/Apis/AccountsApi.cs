

using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.AccountService.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


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

        return api;
    }

    public static async Task<Guid> RegisterUserAsync(
        RegisterUserCommand command, 
        [FromServices] IMediator mediator)
    {
        var idNewUser = await mediator.Send(command);

        return idNewUser;
    }

    public static async Task<ResultUserLoginSuccess> LoginUserAsync(
        LoginUserCommand command, 
        [FromServices] IMediator mediator)
    {
        var result = await mediator.Send(command);

        return result;
    }
}