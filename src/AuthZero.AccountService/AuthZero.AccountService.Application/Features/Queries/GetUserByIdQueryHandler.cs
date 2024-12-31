
using AuthZero.Shared.Exceptions;
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
            Console.WriteLine("Query from cache");

            return JsonConvert.DeserializeObject<UserResponse>(userCaching) ?? throw new NotFoundDataException("User", "User.NotFound");
        }

        var user = await _userRepository.GetByIdAsync(request.Id);

        Console.WriteLine("Query from database");

        if (user is null)
        {
            throw new NotFoundDataException("User", "User.NotFound");
        }

        await _cache.SetStringAsync($"user.{request.Id}", JsonConvert.SerializeObject(new UserResponse(user)));

        return new UserResponse(user);
    }
}