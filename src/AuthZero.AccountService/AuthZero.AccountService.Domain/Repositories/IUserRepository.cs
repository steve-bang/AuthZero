
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.Repositories;

/// <summary>
/// The user repository interface.
/// </summary>
public interface IUserRepository : IRepository
{
        /// <summary>
    /// Adds the user.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns></returns>
    Task<User> AddAsync(User user);

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    User Update(User user);

    /// <summary>
    /// Gets the user by email.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns></returns>
    Task<User?> GetByEmailAsync(string email);

    /// <summary>
    /// Checks if the email user exists.
    /// </summary>
    /// <param name="email">The email.</param>
    /// <returns></returns>
    Task<bool> ExistsEmailAsync(string email);

    /// <summary>
    /// Gets the user by id.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<User?> GetByIdAsync(Guid id);

}