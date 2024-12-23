
namespace AuthZero.AccountService.Application.Models;

public class ResultUserLoginSuccess
{
    /// <summary>
    /// The id of the user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The access token of the user.
    /// </summary>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// The refresh token of the user.
    /// </summary>
    public string RefreshToken { get; set; } = string.Empty;

    public string TokenType { get; set; } = "Bearer";

    public DateTime ExpiresIn { get; set; }

    public ResultUserLoginSuccess()
    {
    }

    public ResultUserLoginSuccess(Guid id, string accessToken, string refreshToken, DateTime expiresIn)
    {
        Id = id;
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        ExpiresIn = expiresIn;
    }
}