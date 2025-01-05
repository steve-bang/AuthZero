
using System.Net;

namespace AuthZero.Shared.Models;

public class ApiErrorResponse 
{
    public int HttpCode { get; }

    public string Code { get; }

    public string Message { get; }

    public ApiErrorResponse(int httpStatus, string code, string message)
    {
        HttpCode = httpStatus;
        Code = code;
        Message = message;
    }

    public static ApiErrorResponse Create(int httpCode, string code, string message)
    {
        return new ApiErrorResponse(httpCode, code, message);
    }

        public static ApiErrorResponse Create(HttpStatusCode httpCode, string code, string message)
    {
        return new ApiErrorResponse((int)httpCode, code, message);
    }

}