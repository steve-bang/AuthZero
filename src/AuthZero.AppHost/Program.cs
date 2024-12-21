var builder = DistributedApplication.CreateBuilder(args);

// Define the SQL Server password, this value will be read from Parameters.password in the AppSettings.json file
var passwordDatabase = builder.AddParameter(
    name: "password",
    secret: true);

// Define the SQL Server connection string
var sqlServerAccountService = builder.AddSqlServer("sql")
    .WithDataBindMount(source: "/Users/mrsteve.bang/Documents/Database/SqlServer/AuthZero");

// Add a database to the SQL Server is AuthZero.Account
// This is a name connection with "Account" and it's used by the AuthZero.AccountService project.
var dbAccount = sqlServerAccountService.AddDatabase("Account");

builder.AddProject<Projects.AuthZero_AccountService_WebApi>("AccountService-WebApi")
        .WithReference(dbAccount); // Add a reference to the database

builder.AddProject<Projects.AuthZero_WebApp>("AuthZero-WebApp");

await builder.Build().RunAsync();
