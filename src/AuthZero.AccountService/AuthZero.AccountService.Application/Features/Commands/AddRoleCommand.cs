
namespace AuthZero.AccountService.Application.Features.Commands;

public record AddRoleCommand(
    string Name,
    string Description
) : IRequest<Guid>;