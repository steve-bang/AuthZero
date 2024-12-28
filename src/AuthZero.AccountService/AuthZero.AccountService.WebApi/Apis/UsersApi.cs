
using System.Security.Claims;
using AuthZero.AccountService.Application.Features.Commands;
using AuthZero.AccountService.Application.Features.Queries;
using AuthZero.AccountService.Application.Models;
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

        // GET api/accounts/{id}
        // If the id is me, it will return the current user id
        // Otherwise, it will return the user id by the id provided
        api.MapGet("{id}", GetUserByIdAsync).RequireAuthorization();

        api.MapPatch("{id}", UpdateUserById).RequireAuthorization();

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
        EditUserCommand editUserCommand = new EditUserCommand(
            Id: id, 
            AvatarUrl: userEditRequest.AvatarUrl, 
            Bio: userEditRequest.Bio,
            FirstName: userEditRequest.FirstName,
            LastName: userEditRequest.LastName);

        var result = await accountService.Mediator.Send(editUserCommand);

        return ApiResponse<bool>.Success(result);
    }
}