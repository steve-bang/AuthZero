
using System.Net;

namespace AuthZero.Shared.Exceptions;

public class UnauthorizedException : BaseExceptionHandler
{
    public UnauthorizedException() : base(
        "User.Unauthorized",
        "User is not authorized to perform this action."
    )
    {
        HttpCode = HttpStatusCode.Unauthorized;
    }
}