
namespace AuthZero.AccountService.Application.Features.Commands;

public record AssignRoleCommand(
    Guid UserId,
    Guid[] Roles
) : IRequest<bool>;