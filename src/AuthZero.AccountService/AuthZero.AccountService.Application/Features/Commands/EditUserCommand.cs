
namespace AuthZero.AccountService.Application.Features.Commands;

public record EditUserCommand(
    Guid Id,
    string AvatarUrl,
    string Bio,
    string FirstName,
    string LastName
) : IRequest<bool>;