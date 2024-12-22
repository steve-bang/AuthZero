


namespace AuthZero.AccountService.Application.Features.Commands;

/// <summary>
/// Registers a new user.
/// </summary>
/// <param name="EmailAddress">The email address of the user.</param>
/// <param name="Password">The password of the user.</param>
/// <param name="PasswordConfirmation">The confirmation of the password.</param>
public record RegisterUserCommand(
    string EmailAddress,
    string Password,
    string PasswordConfirmation
) : IRequest<Guid>;

