using AuthZero.AppHost.Shared.Constants;
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
            //config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        // Add the Kafka services
        builder.AddKafkaProducer<string, string>(Names.KafkaMessages);

        // Add Redis services
        builder.AddRedisDistributedCache("caching");

        return builder;
    }
}