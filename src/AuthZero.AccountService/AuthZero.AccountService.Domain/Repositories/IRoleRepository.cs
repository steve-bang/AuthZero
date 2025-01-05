
using AuthZero.AccountService.Domain.AggregatesModel;
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.Repositories;

/// <summary>
/// The user repository interface.
/// </summary>
public interface IRoleRepository : IRepository
{
    /// <summary>
    /// Add a new role.
    /// </summary>
    /// <param name="role">The role data.</param>
    /// <returns>The added role.</returns>
    Task<Role> AddAsync(Role role);

    /// <summary>
    /// Gets the role by name.
    /// </summary>
    /// <param name="name">The name of the role.</param>
    /// <returns>Returns the role.</returns>
    Task<Role?> GetByNameAsync(string name);

    /// <summary>
    /// Gets the role by id.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Returns the role.</returns>
    Task<Role?> GetByIdAsync(Guid id);


    /// <summary>
    /// Gets the roles by ids.
    /// </summary>
    /// <param name="ids">The role identifiers.</param>
    /// <returns>Returns the roles.</returns>
    Task<IEnumerable<Role>> GetRolesByIdsAsync(IEnumerable<Guid> ids);


}