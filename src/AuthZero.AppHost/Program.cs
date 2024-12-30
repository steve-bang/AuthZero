var builder = DistributedApplication.CreateBuilder(args);

// Define the SQL Server password, this value will be read from Parameters.password in the AppSettings.json file
var passwordDatabase = builder.AddParameter(
    name: "password",
    secret: true);

var portDatabase = builder.AddParameter(
    name: "port",
    secret: false);

var kafka = builder.AddKafka(name: "account-messages", port: 9092)
    .WithKafkaUI()
    .WithLifetime(ContainerLifetime.Persistent);

// Define the SQL Server connection string
var sqlServerAccountService = builder
    .AddSqlServer(
        "sql"
        //, port: int.Parse(portDatabase.Resource.Value)
    )
    .WithDataBindMount(source: "../../database")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("Account");

// Add a database to the SQL Server is AuthZero.Account
// This is a name connection with "Account" and it's used by the AuthZero.AccountService project.

// builder.AddProject<Projects.MigrationService>("account-migration-service")
//     .WithReference(sqlServerAccountService);


builder.AddProject<Projects.AuthZero_AccountService_WebApi>("AccountService-WebApi")
        .WithReference(sqlServerAccountService).WaitFor(sqlServerAccountService)
        .WithReference(kafka);

builder.AddProject<Projects.NotificationService_WebApi>("NotificationService-WebApi")
    .WithReference(kafka);


builder.AddProject<Projects.AuthZero_WebApp>("AuthZero-WebApp");

await builder.Build().RunAsync();
