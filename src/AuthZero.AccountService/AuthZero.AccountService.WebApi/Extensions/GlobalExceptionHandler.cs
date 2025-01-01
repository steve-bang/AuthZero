
using AuthZero.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

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
            // Create a ProblemDetails object to return as the response
            var problemDetails1 = new ProblemDetails
            {
                Title = exceptionHandler.ErrorCode,
                Status = (int)exceptionHandler.HttpCode,
                Detail = exceptionHandler.Message
            };

            // Set the response status code to the exception's status code
            httpContext.Response.StatusCode = (int)exceptionHandler.HttpCode;

            // Await the WriteAsJsonAsync method to ensure the response is written before the method returns
            await httpContext.Response.WriteAsJsonAsync(problemDetails1, cancellationToken);

            return true;
        }
        else
        {
            // Create a ProblemDetails object to return as the response
            var problemDetails = new ProblemDetails
            {
                Title = "An error occurred",
                Status = StatusCodes.Status500InternalServerError,
                Detail = exception.Message
            };

            // Set the response status code to 500
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Await the WriteAsJsonAsync method to ensure the response is written before the method returns
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

    }
}
