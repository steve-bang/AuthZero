
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.Shared.Exceptions;

namespace AuthZero.AccountService.Application.Features.Commands;

public record RevokeRolesCommandHandler(
    IRoleRepository _roleRepository,
    IUserRepository _userRepository
) : IRequestHandler<RevokeRolesCommand, bool>
{

    public async Task<bool> Handle(RevokeRolesCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
        {
            throw new NotFoundDataException(nameof(User), "User.NotFound");
        }

        var roles = user.Roles.Where(r => request.Roles.Contains(r.Id)).ToList();

        if (roles.Count == 0)
        {
            return false;
        }

        user.RevokeRoles(roles);

        _userRepository.Update(user);

        bool result = await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        
        return result;
    }
}