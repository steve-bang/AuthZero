
namespace AuthZero.AccountService.Application.Features.Commands;

public class LoginUserCommandHandler
(
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher
) : IRequestHandler<LoginUserCommand, ResultUserLoginSuccess>
{
    public async Task<ResultUserLoginSuccess> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        // Get the user by email address
        User? user = await _userRepository.GetByEmailAsync(request.EmailAddress);

        // If the user is not found, return a failure result
        if (user is null) 
            return new ResultUserLoginSuccess();

        // Verify the password
        if (!_passwordHasher.Verify(request.Password, user.PasswordHash, user.Salt))
            return new ResultUserLoginSuccess();

        // Update the last login date
        user.UpdateLastLogin();

        _userRepository.Update(user);

        // Save the changes
        _ = _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new ResultUserLoginSuccess
        {
            Id = user.Id,
            AccessToken = "access_token",
            RefreshToken = "refresh_token"
        };

    }
}