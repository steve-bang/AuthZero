
using AuthZero.Shared.Exceptions;
using AuthZero.Shared.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace AuthZero.AccountService.WebApi.Extensions;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // Log the exception
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var exceptionHandler = exception as BaseExceptionHandler;

        if (exceptionHandler != null)
        {

            // Set the response status code to the exception's status code
            httpContext.Response.StatusCode = (int)exceptionHandler.HttpCode;

            // Await the WriteAsJsonAsync method to ensure the response is written before the method returns
            await httpContext.Response.WriteAsJsonAsync(
                ApiErrorResponse.Create(
                    httpCode: exceptionHandler.HttpCode,
                    code: exceptionHandler.ErrorCode,
                    message: exceptionHandler.Message),
                cancellationToken);

            return true;
        }
        else
        {
            // Set the response status code to 500
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Await the WriteAsJsonAsync method to ensure the response is written before the method returns
            await httpContext.Response.WriteAsJsonAsync(
                ApiErrorResponse.Create(
                    httpCode: StatusCodes.Status500InternalServerError,
                    code: "Server.InternalServerError",
                    message: exception.Message),
                cancellationToken);

            return true;
        }

    }
}
