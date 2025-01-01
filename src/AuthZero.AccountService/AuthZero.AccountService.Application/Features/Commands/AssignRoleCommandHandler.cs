
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.Shared.Exceptions;

namespace AuthZero.AccountService.Application.Features.Commands;

public record AssignRoleCommandHandler(
    IRoleRepository _roleRepository,
    IUserRepository _userRepository
) : IRequestHandler<AssignRoleCommand, bool>
{

    public async Task<bool> Handle(AssignRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new NotFoundDataException(nameof(User), "User.NotFound");
        }

        var roles = await _roleRepository.GetRolesByIdsAsync(request.Roles);

        if (roles == null)
        {
            throw new NotFoundDataException(nameof(Role), "Role.NotFound");
        }

        user.AssignRoles(roles);

        _userRepository.Update(user);

        bool result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        
        return result;
    }
}