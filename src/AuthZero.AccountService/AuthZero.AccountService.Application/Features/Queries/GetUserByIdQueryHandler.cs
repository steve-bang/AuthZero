
using AuthZero.Shared.Exceptions;

namespace AuthZero.AccountService.Application.Features.Queries;

public class GetUserByIdQueryHandler(
    IUserRepository _userRepository
) : IRequestHandler<GetUserByIdQuery, User>
{

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundDataException("User", "User.NotFound");
        }

        return user;
    }
}