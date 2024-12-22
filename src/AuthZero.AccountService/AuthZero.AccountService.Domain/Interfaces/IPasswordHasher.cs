
namespace AuthZero.AccountService.Domain.Interfaces; 


public interface IPasswordHasher
{
    /// <summary>
    /// Hashes a password and returns the hash and salt.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="salt">The salt used to hash the password.</param>
    /// <returns>The hashed password.</returns>
    string Hash(string password, out string salt);

}