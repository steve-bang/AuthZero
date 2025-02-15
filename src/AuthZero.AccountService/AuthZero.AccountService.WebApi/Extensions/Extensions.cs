
using AuthZero.AccountService.Application;
using AuthZero.AccountService.Domain.Interfaces;
using AuthZero.AccountService.Domain.Repositories;
using AuthZero.AccountService.Infrastructure;
using AuthZero.AccountService.Infrastructure.Common;
using AuthZero.AccountService.Infrastructure.Interfaces;
using AuthZero.AccountService.Infrastructure.Repositories;
using AuthZero.ServiceDefaults;
using AuthZero.Shared;
using Microsoft.EntityFrameworkCore;


namespace AuthZero.AccountService.WebApi.Extensions;

public static class Extensions
{
    /// <summary>
    /// Add the application services to the application
    /// </summary>
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;

        // Add the database context
        builder.AddDatabaseContext();

        // Add the application services
        builder.AddApplication();

        // Add the default authentication
        builder.AddDefaultAuthentication();

        // Add the password hasher
        builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

        
        // Add the JWT settings
        var jwtSettings = configuration.GetSection("Identity");
        if(!jwtSettings.Exists())
        {
            throw new NotImplementedException("JwtSettings section is missing in the appsettings.json file.");    
        }

        var jwtSettingsValue = jwtSettings.Get<JwtSettings>();

        if(jwtSettingsValue == null)
        {
            throw new NotImplementedException("JwtSettings section is missing in the appsettings.json file.");    
        }
        builder.Services.AddSingleton(jwtSettingsValue);

        // Add the JWT provider
        builder.Services.AddScoped<IJwtProvider, JwtProvider>();
        
        // Add the repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    }


    /// <summary>
    /// Add the database context to the application
    /// </summary>
    public static void AddDatabaseContext(this IHostApplicationBuilder builder)
    {
        // This is the connection string name in the AppHost project provide. See in the AuthZero.AppHost/Program.cs
        string connectionName = "Account";

        builder.Services.AddDbContext<AccountServiceContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString(connectionName), sqlOptions =>
            {
            }));
        builder.EnrichSqlServerDbContext<AccountServiceContext>();

        // Add the migration service. When the application starts, it will check if the database is up to date. 
        // If not, it will run the migration to update the database.
        builder.Services.AddMigration<AccountServiceContext>();
    }
}