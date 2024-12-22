
using AuthZero.AccountService.Infrastructure;

namespace AuthZero.AccountService.WebApi.Extensions;

public static class Extensions
{
    /// <summary>
    /// Add the application services to the application
    /// </summary>
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        // Add the database context
        builder.AddDatabaseContext();
    }


    /// <summary>
    /// Add the database context to the application
    /// </summary>
    public static void AddDatabaseContext(this IHostApplicationBuilder builder)
    {
        // This is the connection string name in the AppHost project provide. See in the AuthZero.AppHost/Program.cs
        string connectionName = "Account";

        builder.AddSqlServerDbContext<AccountServiceContext>(connectionName: connectionName);

        // Add the migration service. When the application starts, it will check if the database is up to date. 
        // If not, it will run the migration to update the database.
        builder.Services.AddMigration<AccountServiceContext>();
    }
}