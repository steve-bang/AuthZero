
using System.Net;

namespace AuthZero.Shared.Exceptions;

public class NotFoundDataException : BaseExceptionHandler
{
    public NotFoundDataException(string entity, string code) : base(
        code,
        string.Format("The {0} was not found.", entity)
    )
    {
        HttpCode = HttpStatusCode.NotFound;
    }
}