
namespace AuthZero.AccountService.Application.Features.Commands;


public record LogoutCommand(
    string AccessToken
) : IRequest<bool>;