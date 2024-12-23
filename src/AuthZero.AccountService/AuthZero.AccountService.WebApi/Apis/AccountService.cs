using MediatR;

namespace AuthZero.AccountService.Apis;

public class AccountService(
    IMediator mediator,
    IHttpContextAccessor httpContextAccessor,
    ILogger<AccountService> logger)
{
    public IMediator Mediator { get; set; } = mediator;
    public ILogger<AccountService> Logger { get; } = logger;

    public IHttpContextAccessor HttpContextAccessor { get; } = httpContextAccessor;
}