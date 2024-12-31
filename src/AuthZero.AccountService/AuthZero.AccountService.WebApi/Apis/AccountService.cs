using MediatR;

namespace AuthZero.AccountService.Apis;

public class AccountService(
    IMediator mediator,
    IHttpContextAccessor httpContextAccessor
)
{
    public IMediator Mediator { get; set; } = mediator;

    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
}