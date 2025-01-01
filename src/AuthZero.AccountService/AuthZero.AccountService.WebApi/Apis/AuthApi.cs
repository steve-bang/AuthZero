
using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.AccountService.Application.Models;
using AuthZero.Shared.Models;



namespace AuthZero.AccountService.Apis;

public static class AuthApi
{
    public static RouteGroupBuilder MapAuthApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/v1/auth");

        // POST api/accounts/register
        // Register a new user
        api.MapPost("register", RegisterUserAsync);

        // POST api/accounts/login
        // Login a user
        api.MapPost("login", LoginUserAsync);


        return api;
    }

    public static async Task<ApiResponse<Guid>> RegisterUserAsync(
        RegisterUserCommand command, 
        [AsParameters] AccountService accountService)
    {
        var idNewUser = await accountService.Mediator.Send(command);

        return ApiResponse<Guid>.Created(idNewUser);
    }

    public static async Task<ApiResponse<ResultUserLoginSuccess>> LoginUserAsync(
        LoginUserCommand command, 
        [AsParameters] AccountService accountService)
    {
        var result = await accountService.Mediator.Send(command);

        return ApiResponse<ResultUserLoginSuccess>.Success(result);
    }
}