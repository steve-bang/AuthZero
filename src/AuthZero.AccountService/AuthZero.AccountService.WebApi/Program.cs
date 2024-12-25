
using AuthZero.AccountService.Apis;
using AuthZero.AccountService.WebApi.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddApplicationServices();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapDefaultEndpoints();

// Maps all API endpoints
app.MapAccountsApiV1();

app.UseDefaultOpenApi();

app.UseExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();


await app.RunAsync();

