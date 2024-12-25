
using System.Net;

namespace AuthZero.Shared.Exceptions;

public class BaseExceptionHandler : Exception
{
    public HttpStatusCode HttpCode { get; set; } = HttpStatusCode.InternalServerError;
    public string ErrorCode { get; set; }


    public BaseExceptionHandler(string errorCode, string message) : base(message)
    {
        ErrorCode = errorCode;
    }
}