using AuthZero.AccountService.Application.Behaviors;
using AuthZero.AccountService.Application.Caching;
using AuthZero.AppHost.Shared.Constants;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthZero.AccountService.Application;

public static class DependencyInjection
{
    public static IHostApplicationBuilder AddApplication(this IHostApplicationBuilder builder)
    {
        // Add the MediatR services
        builder.Services.AddMediatR(config =>
        {
            // Register all the handlers from the current assembly
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            // Register the ValidationBehavior
            config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        builder.Services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        // Add the Kafka services
        builder.AddKafkaProducer<string, string>(Names.KafkaMessages);

        // Add Redis services
        builder.AddRedisDistributedCache("caching");

        // Register service
        builder.Services.AddScoped<ISessionCaching, SessionCaching>();

        return builder;
    }
}