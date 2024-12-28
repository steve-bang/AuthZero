
using AuthZero.Shared.Exceptions;

namespace AuthZero.AccountService.Application.Features.Queries;

public class GetUserByIdQueryHandler(
    IUserRepository _userRepository
) : IRequestHandler<GetUserByIdQuery, UserResponse>
{

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            throw new NotFoundDataException("User", "User.NotFound");
        }

        return new UserResponse(user);
    }
}