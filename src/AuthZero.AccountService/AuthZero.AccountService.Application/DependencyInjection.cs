using Microsoft.Extensions.DependencyInjection;

namespace AuthZero.AccountService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add the MediatR services
        services.AddMediatR(config =>
        {
            // Register all the handlers from the current assembly
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            // Register the ValidationBehavior
            //config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        return services;
    }

}