using AuthZero.AppHost.Shared.Constants;
using AuthZero.NotificationService;
using AuthZero.NotificationService.WebApi.Services;
using Confluent.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.AddKafkaConsumer<string, string>(Names.KafkaMessages, options =>
{
    options.Config.GroupId = "my-consumer-group";
    options.Config.AutoOffsetReset = AutoOffsetReset.Earliest;
    options.Config.EnableAutoCommit = false;
});


builder.Services.AddHostedService<NotificationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


await app.RunAsync();

