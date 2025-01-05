
using Microsoft.Extensions.Caching.Distributed;

namespace AuthZero.AccountService.Application.Caching;


public class SessionCaching(IDistributedCache caching) : ISessionCaching
{
    public const string KeyPattern = "session_{0}";

    public async Task SetAccessTokenAsync(string accessToken, DateTime expriryTime)
    {
        await caching.SetStringAsync(string.Format(KeyPattern, accessToken), accessToken, 
            new DistributedCacheEntryOptions()
            .SetAbsoluteExpiration(expriryTime.TimeOfDay)
            .SetSlidingExpiration(expriryTime.TimeOfDay)
        );
    }

    public async Task<string?> GetAccessTokenAsync(string accessToken)
    {
        var accessTokenBytes = await caching.GetAsync(string.Format(KeyPattern, accessToken));

        if(accessTokenBytes == null) return null; 

        return System.Text.Encoding.UTF8.GetString(accessTokenBytes);

    }

    public async Task RemoveAccessTokenAsync(string accessToken)
    {
        await caching.RemoveAsync(string.Format(KeyPattern, accessToken));
    }

}