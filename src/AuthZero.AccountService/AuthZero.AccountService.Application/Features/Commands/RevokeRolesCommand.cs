
namespace AuthZero.AccountService.Application.Features.Commands;

public record RevokeRolesCommand(
    Guid UserId,
    Guid[] Roles
) : IRequest<bool>;