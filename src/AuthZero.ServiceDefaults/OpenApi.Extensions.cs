

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;

public static partial class Extensions
{
    public static IHostApplicationBuilder MapOpenApi(this IHostApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();

        return builder;
    }

    public static IApplicationBuilder UseDefaultOpenApi(this WebApplication app)
    {
        var configuration = app.Configuration;
        var openApiSection = configuration.GetSection("OpenApi");

        if (!openApiSection.Exists())
        {
            return app;
        }

        app.MapOpenApi();

        return app;
    }
}