
namespace AuthZero.AccountService.Domain.Common;

public interface IRepository
{
    IUnitOfWork UnitOfWork { get; }
}