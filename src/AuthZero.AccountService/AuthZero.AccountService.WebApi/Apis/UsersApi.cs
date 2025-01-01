
using System.Security.Claims;
using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.AccountService.Application.Features.Queries;
using AuthZero.AccountService.Application.Models;
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.WebApi.Models;
using AuthZero.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthZero.AccountService.Apis;

public static class UserApi
{
    public static RouteGroupBuilder MapUserApi(this IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup("api/v1/users");

        // GET api/v1/users/{id}
        // If the id is me, it will return the current user id
        // Otherwise, it will return the user id by the id provided
        api.MapGet("{id}", GetUserByIdAsync).RequireAuthorization();

        // PATCH api/v1/users/{id}
        // Update user by id
        // If the id is me, it will update the current user id
        api.MapPatch("{id}", UpdateUserById).RequireAuthorization();

        // POST api/v1/users/{id}/roles
        // Assign roles to the user
        api.MapPost("{id}/roles", AssignRoles).RequireAuthorization();

        // GET api/v1/users/{id}/roles
        // Gets the roles of the user
        api.MapGet("{id}/roles", GetRoles).RequireAuthorization();       

        // DELETE api/v1/users/{id}/roles
        // Revoke roles from the user
        api.MapDelete("{id}/roles", RevokeRoles).RequireAuthorization();

        return api;
    }

    public static async Task<ApiResponse<UserResponse>> GetUserByIdAsync(
        string id, 
        [AsParameters] AccountService accountService
    )
    {

        // If the id is me, it will return the current user id
        if (id == "me")
        {
            var userIdentity = accountService.HttpContextAccessor.HttpContext?.User;

            id = userIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        // Otherwise, it will return the user id by the id provided
        GetUserByIdQuery query = new(Guid.Parse(id));

        UserResponse user = await accountService.Mediator.Send(query);

        return ApiResponse<UserResponse>.Success(user);
    }

    public static async Task<ApiResponse<bool>> UpdateUserById(
        Guid id,
        [FromBody] UserEditRequest userEditRequest, 
        [AsParameters] AccountService accountService
    )
    {
        EditUserCommand editUserCommand = new(
            Id: id, 
            AvatarUrl: userEditRequest.AvatarUrl, 
            Bio: userEditRequest.Bio,
            FirstName: userEditRequest.FirstName,
            LastName: userEditRequest.LastName);

        var result = await accountService.Mediator.Send(editUserCommand);

        return ApiResponse<bool>.Success(result);
    }

    public static async Task<ApiResponse<bool>> AssignRoles(
        Guid id,
        [FromBody] AssignRolesRequest assignRolesRequest, 
        [AsParameters] AccountService accountService
    )
    {
        AssignRoleCommand assignRoleCommand = new(
            UserId: id, 
            Roles: assignRolesRequest.Roles);

        var result = await accountService.Mediator.Send(assignRoleCommand);

        return ApiResponse<bool>.Success(result);
    }

    public static async Task<ApiResponse<RoleResponse[]>> GetRoles(
        Guid id,
        [AsParameters] AccountService accountService
    )
    {
        GetRolesByUserQuery query = new(UserId: id);

        var result = await accountService.Mediator.Send(query);

        return ApiResponse<RoleResponse[]>.Success(result);
    }

    public static async Task<ApiResponse<bool>> RevokeRoles(
        Guid id,
        [FromBody] AssignRolesRequest assignRolesRequest, 
        [AsParameters] AccountService accountService
    )
    {
        RevokeRolesCommand assignRoleCommand = new(
            UserId: id, 
            Roles: assignRolesRequest.Roles);

        var result = await accountService.Mediator.Send(assignRoleCommand);

        return ApiResponse<bool>.Success(result);
    }
}