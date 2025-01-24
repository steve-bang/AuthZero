

using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace AuthZero.AccountService.Application.Features.Queries;

public class GetUserByIdQueryHandler(
    IUserRepository _userRepository,
    IDistributedCache _cache
) : IRequestHandler<GetUserByIdQuery, UserResponse>
{

    public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userCaching = await _cache.GetStringAsync($"user.{request.Id}");

        if(userCaching is not null)
        {
            return JsonConvert.DeserializeObject<UserResponse>(userCaching) ?? throw UserError.UserNotFound;;
        }

        var user = await _userRepository.GetByIdAsync(request.Id) ?? throw UserError.UserNotFound;
        
        await _cache.SetStringAsync($"user.{request.Id}", JsonConvert.SerializeObject(new UserResponse(user)));

        return new UserResponse(user);
    }
}