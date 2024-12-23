
namespace AuthZero.AccountService.Infrastructure.Common
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }
        
        public string Secret { get; set; }

        public int AccessTokenExpiryMinutes { get; set; }
        public int RefreshTokenExpiryMinutes { get; set; }
    }
}