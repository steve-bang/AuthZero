
namespace AuthZero.AccountService.Application.Features.Commands;

/// <summary>
/// Handles the <see cref="RegisterUserCommand"/>.
/// </summary>
public class RegisterUserCommandHanlder(
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher
) : IRequestHandler<RegisterUserCommand, Guid>
{
    public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Hash the password
        string passwordHash = _passwordHasher.Hash(request.Password, out string salt);

        // Create a new user
        User user = User.Register(
            request.EmailAddress,
            passwordHash,
            salt
        );

        // Add the user to the repository
       user = await _userRepository.AddAsync(user);

        // Save changes with the Unit of Work
        await _userRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return user.Id;
    }
}