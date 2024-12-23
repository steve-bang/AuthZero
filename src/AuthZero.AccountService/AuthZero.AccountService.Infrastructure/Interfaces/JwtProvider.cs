
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Interfaces;
using AuthZero.AccountService.Infrastructure.Common;
using Microsoft.IdentityModel.Tokens;

namespace AuthZero.AccountService.Infrastructure.Interfaces;

public class JwtProvider : IJwtProvider
{
    private readonly JwtSettings _jwtSettings;

    public JwtProvider(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public void GenerateToken(User user, out string accessToken, out string refreshToken, out DateTime expires)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.EmailAddress),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        expires = DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes);

        // Generate the tokens
        accessToken =  new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            claims: claims,
            expires: expires,
            audience: _jwtSettings.Audience,
            signingCredentials: signingCredentials
        ));

        // Generate the refresh token
        refreshToken = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.RefreshTokenExpiryMinutes),
            audience: _jwtSettings.Audience,
            signingCredentials: signingCredentials
        ));
    }

    public IEnumerable<Claim> ValidateToken(string token)
    {
        throw new NotImplementedException();
    }
}