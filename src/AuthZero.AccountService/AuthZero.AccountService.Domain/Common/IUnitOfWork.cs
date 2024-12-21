
namespace AuthZero.AccountService.Domain.Common;

/// <summary>
/// Represents a unit of work.
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

}