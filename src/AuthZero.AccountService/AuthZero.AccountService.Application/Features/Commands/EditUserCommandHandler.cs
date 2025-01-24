

namespace AuthZero.AccountService.Application.Features.Commands;

public class EditUserCommandHandler(
    IUserRepository _userRepository
) : IRequestHandler<EditUserCommand, bool>
{
    public async Task<bool> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userRepository.GetByIdAsync(request.Id);

        if(user is null)
            throw UserError.UserNotFound;

        user.Edit(
            avatarUrl: request.AvatarUrl,
            bio: request.Bio,
            firstName: request.FirstName,
            lastName: request.LastName
        );

        await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return true;
    }
}