
namespace AuthZero.AccountService.Application.Features.Commands;

public class LoginUserCommandHandler
(
    IUserRepository _userRepository,
    IPasswordHasher _passwordHasher,
    IJwtProvider _jwtProvider
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
        user.Login();

        _userRepository.Update(user);

        // Save the changes
        _ = _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);


        // Generate the JWT token
        _jwtProvider.GenerateToken(user, out string accessToken, out string refreshToken, out DateTime accessTokenExpiry);

        // Return the success result
        return new ResultUserLoginSuccess(
            id: user.Id,
            accessToken: accessToken,
            refreshToken: refreshToken,
            expiresIn: accessTokenExpiry
        );

    }
}