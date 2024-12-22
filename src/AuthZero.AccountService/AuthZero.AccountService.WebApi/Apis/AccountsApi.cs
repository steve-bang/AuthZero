

using AuthZero.AccountService.Application.Features.Commands;
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

        return api;
    }

    public static async Task<Guid> RegisterUserAsync(
        RegisterUserCommand command, 
        [FromServices] IMediator mediator)
    {
        var idNewUser = await mediator.Send(command);

        return idNewUser;
    }
}