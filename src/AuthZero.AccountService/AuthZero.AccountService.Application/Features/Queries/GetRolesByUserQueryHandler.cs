
namespace AuthZero.AccountService.Application.Features.Commands;

public record GetRolesByUserQueryHandler(
    IUserRepository _userRepository
) : IRequestHandler<GetRolesByUserQuery, RoleResponse[]>
{

    public async Task<RoleResponse[]> Handle(GetRolesByUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null)
            throw UserError.UserNotFound;
        
        return user.Roles.Select(r => new RoleResponse(
            r.Id,
            r.Name,
            r.Description
        )).ToArray();
    }
}