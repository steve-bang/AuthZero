
using AuthZero.AccountService.Domain.AggregatesModel;

namespace AuthZero.AccountService.Application.Features.Commands;

public record GetRolesByUserQuery(
    Guid UserId
) : IRequest<RoleResponse[]>;