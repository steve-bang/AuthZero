
using System.Security.Cryptography;
using System.Text;
using AuthZero.AccountService.Domain.Interfaces;

namespace AuthZero.AccountService.Infrastructure.Interfaces
{

    public class PasswordHasher : IPasswordHasher
    {
        private const int HashSize = 64;

        private const int SaltSize = 128;

        private const int Iterations = 350000;

        private readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA512;

                /// <summary>
        /// Hashes the password using the salt.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt to use.</param>
        /// <returns></returns>
        private string HashPassword(string password, byte[] salt)
        {
            // Hash the password and encode the parameters
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithm, HashSize);

            return Convert.ToBase64String(hash);
        }

        /// <inheritdoc />
        public string Hash(string password, out string salt)
        {
            // Generate a random salt
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }

            salt = Convert.ToBase64String(saltBytes);

            return HashPassword(password, saltBytes);
        }

    }
}