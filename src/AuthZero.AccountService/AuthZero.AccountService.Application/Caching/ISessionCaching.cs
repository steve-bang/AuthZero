
namespace AuthZero.AccountService.Application.Caching;

public interface ISessionCaching
{
    Task SetAccessTokenAsync(string accessToken, DateTime expriryTime);

    Task<string?> GetAccessTokenAsync(string accessToken);

    Task RemoveAccessTokenAsync(string accessToken);
}
