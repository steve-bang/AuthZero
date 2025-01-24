
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Common;
using AuthZero.AccountService.Domain.Repositories;

namespace AuthZero.AccountService.Infrastructure.Repositories; 

public class UserRepository : IUserRepository
{
    private readonly AccountServiceContext _dbContext;
    public IUnitOfWork UnitOfWork => _dbContext;

    public UserRepository(AccountServiceContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    /// <inheritdoc/>
    public async Task<User> AddAsync(User user)
    {
        var userAdded = await _dbContext.Users.AddAsync(user);

        return userAdded.Entity;
    }

    /// <inheritdoc/>
    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _dbContext
                    .Users
                    .Include(u => u.Roles)
                    .FirstOrDefaultAsync(u => u.Id == id);
    }

    /// <inheritdoc/>
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress == email);
    }

    /// <inheritdoc/>
    public User Update(User user)
    {
       return _dbContext
                .Users
                .Update(user)
                .Entity;
    }

    public async Task<bool> ExistsEmailAsync(string email)
    {
        return (await _dbContext
            .Users
            .Where(x => x.EmailAddress == email)
            .Select(u => u.EmailAddress)
            .FirstOrDefaultAsync()) != null;
    }
}