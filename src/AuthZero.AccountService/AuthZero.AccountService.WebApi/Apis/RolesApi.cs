
using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.Shared.Models;

namespace AuthZero.AccountService.Apis;

public static class RolesApi
{
    public static RouteGroupBuilder MapRoleApiV1(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("api/v1/roles");

        // POST api/v1/roles
        // Add a new role to the system
        api.MapPost("", AddRole);


        return api;
    }

    public static async Task<ApiResponse<Guid>> AddRole(
        AddRoleCommand command, 
        [AsParameters] AccountService accountService)
    {
        var roleId = await accountService.Mediator.Send(command);

        return ApiResponse<Guid>.Created(roleId);
    }
}