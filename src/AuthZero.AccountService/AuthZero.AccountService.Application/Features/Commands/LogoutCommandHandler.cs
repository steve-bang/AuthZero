
using AuthZero.AccountService.Application.Caching;

namespace AuthZero.AccountService.Application.Features.Commands;


public class LogoutCommandHandler(
    ISessionCaching _cache
) : IRequestHandler<LogoutCommand, bool>
{
    public async Task<bool> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        var accessToken = await _cache.GetAccessTokenAsync(request.AccessToken);

        if(accessToken == null) return false;

        await _cache.RemoveAccessTokenAsync(accessToken);

        return true;
    }
}