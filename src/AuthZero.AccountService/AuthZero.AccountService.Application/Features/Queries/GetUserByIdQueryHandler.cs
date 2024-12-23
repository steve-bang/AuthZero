
namespace AuthZero.AccountService.Application.Features.Queries;

public class GetUserByIdQueryHandler(
    IUserRepository _userRepository
) : IRequestHandler<GetUserByIdQuery, User?>
{

    public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(request.Id);
    }
}