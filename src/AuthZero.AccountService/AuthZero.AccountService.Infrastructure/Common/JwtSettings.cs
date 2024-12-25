
namespace AuthZero.AccountService.Infrastructure.Common
{
    public class JwtSettings
    {
        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
        
        public string Secret { get; set; } = null!;

        public int AccessTokenExpiryMinutes { get; set; }
        public int RefreshTokenExpiryMinutes { get; set; }
    }
}