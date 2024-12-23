
namespace AuthZero.AccountService.Application.Features.Commands;

/// <summary>
/// Login a user.
/// </summary>
/// <param name="EmailAddress">The email address of the user.</param>
/// <param name="Password">The password of the user.</param>
public record LoginUserCommand(
    string EmailAddress,
    string Password
) : IRequest<ResultUserLoginSuccess>;