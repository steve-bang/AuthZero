
using System.Net;

namespace AuthZero.Shared.Exceptions;

public class BadRequestException : BaseExceptionHandler
{
    public BadRequestException(string code, string messsage) : base( code, messsage)
    {
        HttpCode = HttpStatusCode.BadRequest;
    }
}