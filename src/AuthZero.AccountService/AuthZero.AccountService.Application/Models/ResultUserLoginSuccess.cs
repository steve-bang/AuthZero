
namespace AuthZero.AccountService.Application.Models;

public class ResultUserLoginSuccess
{
    /// <summary>
    /// The id of the user.
    /// </summary>
    /// <example>0accc54b-4305-4907-aa4b-08dd2241c86c</example>
    public Guid Id { get; set; }

    /// <summary>
    /// The access token of the user.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjBhY2NjNTRiLTQzMDUtNDkwNy1hYTRiLTA4ZGQyMjQxYzg2YyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InN0cmluZyIsImV4cCI6MTczNTMyNjM3MCwiaXNzIjoiaHR0cHM6Ly9hdXRoemVyby5jb20iLCJhdWQiOiJodHRwczovL2F1dGh6ZXJvLmNvbSJ9.cq3I_I4rzIWjXbFcmKV6bIRg0aI5gVCBgyxeYVLL_-M</example>
    public string AccessToken { get; set; } = string.Empty;

    /// <summary>
    /// The refresh token of the user.
    /// </summary>
    /// <example>eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjBhY2NjNTRiLTQzMDUtNDkwNy1hYTRiLTA4ZGQyMjQxYzg2YyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6InN0cmluZyIsImV4cCI6MTczNTU0MjM3MCwiaXNzIjoiaHR0cHM6Ly9hdXRoemVyby5jb20iLCJhdWQiOiJodHRwczovL2F1dGh6ZXJvLmNvbSJ9.s39_MXNSYt7c3KFQGZ95vULe8dRkD0cyDQ5OEfvPFxM</example>
    public string RefreshToken { get; set; } = string.Empty;

    /// <summary>
    /// The type of token.
    /// </summary>
    /// <example>Bearer</example>
    public string TokenType { get; set; } = "Bearer";

    /// <summary>
    /// The expiration date of the token.
    /// </summary>
    /// <example>2023-09-06T23:37:50.000Z</example>
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