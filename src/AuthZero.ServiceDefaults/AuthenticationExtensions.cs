
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace AuthZero.ServiceDefaults;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddDefaultAuthentication(this IHostApplicationBuilder builder)
    {
        var servivces = builder.Services;
        var configuration = builder.Configuration;

        // {
        //   "Identity": {
        //     "Issuer": "http://identity",
        //     "Audience": "basket",
        //     "SecretKey": "*******"
        //    }
        // }

        var identitySection = configuration.GetSection("Identity");

        if (!identitySection.Exists())
        {
            return servivces;
        }

        servivces
            .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
            options =>
            {
                var identityUrl = identitySection.GetValue<string>("Issuer");
                var audience = identitySection.GetValue<string>("Audience");
                var secretKey = identitySection.GetValue<string>("Secret");


                options.Authority = identityUrl;
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = identityUrl,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                };
            });

        servivces.AddAuthorization();


        return servivces;
    }
}