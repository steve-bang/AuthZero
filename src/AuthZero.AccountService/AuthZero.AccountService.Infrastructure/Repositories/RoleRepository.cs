
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.Common;
using AuthZero.AccountService.Domain.Repositories;

namespace AuthZero.AccountService.Infrastructure.Repositories; 


public class RoleRepository : IRoleRepository
{
    private readonly AccountServiceContext _dbContext;
    public IUnitOfWork UnitOfWork => _dbContext;

    public RoleRepository(AccountServiceContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <inheritdoc/>
    public async Task<Role> AddAsync(Role role)
    {
        var roleAdded = await _dbContext.Roles.AddAsync(role);

        return roleAdded.Entity;
    }

    /// <inheritdoc/>
    public async Task<Role?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
    }

    /// <inheritdoc/>
    public async Task<Role?> GetByNameAsync(string name)
    {
        return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Role>> GetRolesByIdsAsync(IEnumerable<Guid> ids)
    {
        return await _dbContext.Roles.Where(r => ids.Contains(r.Id)).ToListAsync();
    }

}