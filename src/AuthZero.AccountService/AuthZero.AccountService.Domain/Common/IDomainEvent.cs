
using MediatR;

namespace AuthZero.AccountService.Domain.Common
{
    /// <summary>
    /// Interface for a domain event.
    /// </summary>
    public interface IDomainEvent : INotification
    {
    }
}