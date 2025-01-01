
using System.Security.Claims;
using AuthZero.AccountService.Domain.AggregatesModel.User;

namespace AuthZero.AccountService.Domain.Interfaces; 

public interface IJwtProvider
{
    /// <summary>
    /// Generates a JWT token for a user.
    /// </summary>
    /// <param name="user">The user to generate the token for.</param>
    /// <param name="accessToken">The generated access token.</param>
    /// <param name="refreshToken">The generated refresh token.</param>
    /// <param name="expires">The expiration date of the token.</param>
    void GenerateToken(User user, out string accessToken, out string refreshToken, out DateTime expires);

    /// <summary>
    /// Validates a JWT token.
    /// </summary>
    /// <param name="token">The token to validate.</param>
    /// <returns>The claims from the token.</returns>
    IEnumerable<Claim> ValidateToken(string token);
}