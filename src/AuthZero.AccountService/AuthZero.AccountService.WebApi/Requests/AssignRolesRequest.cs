
namespace AuthZero.AccountService.WebApi.Models;

public record AssignRolesRequest(
    Guid[] Roles
);