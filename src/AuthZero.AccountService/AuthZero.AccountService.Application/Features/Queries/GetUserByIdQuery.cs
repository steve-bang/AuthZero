
namespace AuthZero.AccountService.Application.Features.Queries;

public record GetUserByIdQuery(
    Guid Id
) : IRequest<User>;