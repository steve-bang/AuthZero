var builder = DistributedApplication.CreateBuilder(args);

// Define the SQL Server password, this value will be read from Parameters.password in the AppSettings.json file
// var passwordDatabase = builder.AddParameter(
//     name: "password",
//     secret: true);

// var portDatabase = builder.AddParameter(
//     name: "port",
//     secret: false);

var kafka = builder.AddKafka(name: "kafka-messages", port: 9092)
    .WithKafkaUI()
    .WithLifetime(ContainerLifetime.Persistent);

// Define the SQL Server connection string
var sqlServerAccountService = builder.AddSqlServer("sql")
                                     .WithDataBindMount(source: "../../database")
                                     .WithLifetime(ContainerLifetime.Persistent)
                                     .AddDatabase("Account");

var caching = builder.AddRedis("caching")
                   .WithDataBindMount("../../redis")
                   .WithRedisInsight() // Add RedisInsight to the Redis container
                   .WithRedisCommander(); // Add RedisCommander to the Redis container

// Add a database to the SQL Server is AuthZero.Account
// This is a name connection with "Account" and it's used by the AuthZero.AccountService project.

// builder.AddProject<Projects.MigrationService>("account-migration-service")
//     .WithReference(sqlServerAccountService);



builder.AddProject<Projects.AuthZero_AccountService_WebApi>("account-api")
        .WithReference(sqlServerAccountService).WaitFor(sqlServerAccountService)
        .WithReference(kafka)
        .WithReference(caching);

builder.AddProject<Projects.NotificationService_WebApi>("notification-api")
    .WithReference(kafka);


builder.AddProject<Projects.AuthZero_WebApp>("webapp");

await builder.Build().RunAsync();
