
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.AggregatesModel.User;

/// <summary>
/// This class represents a user in the system.
/// </summary>
public class User : AggregateRoot
{
    /// <summary>
    /// The email address of the user.
    /// </summary>
    public string EmailAddress { get; set; }

    /// <summary>
    /// The password hash of the user.
    /// </summary>
    public string PasswordHash { get; set; }

    /// <summary>
    /// The salt used to hash the password.
    /// </summary>
    public string Salt { get; set; }

    /// <summary>
    /// The avatar URL of the user.
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// The bio of the user.
    /// </summary>
    public string? Bio { get; set; }

    /// <summary>
    /// The first name of the user.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The last name of the user.
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// The last login date of the user.
    /// Will be null if the user has never logged in.
    /// </summary>
    public DateTime? LastLogin { get; set; }

    public DateTime? LastUpdateAt { get; set; }

    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Constructor for the User class.
    /// </summary>
    public User(
        string emailAddress,
        string passwordHash,
        string salt,
        string? avatarUrl = null,
        string? bio = null,
        string? firstName = null,
        string? lastName = null
    )
    {
        EmailAddress = emailAddress;
        PasswordHash = passwordHash;
        Salt = salt;
        AvatarUrl = avatarUrl;
        Bio = bio;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(
        string emailAddress,
        string passwordHash,
        string salt,
        string avatarUrl,
        string bio,
        string firstName,
        string lastName)
    {
        EmailAddress = emailAddress;
        PasswordHash = passwordHash;
        Salt = salt;
        AvatarUrl = avatarUrl;
        Bio = bio;
        FirstName = firstName;
        LastName = lastName;
    }

    /// <summary>
    /// Handles the login of the user.
    /// </summary>
    public void Login()
    {
        LastLogin = DateTime.UtcNow;
    }

    public void UpdatePassword(string passwordHash, string salt)
    {
        PasswordHash = passwordHash;
        Salt = salt;
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    public static User Register(
        string emailAddress,
        string passwordHash,
        string salt,
        string? avatarUrl = null,
        string? bio = null,
        string? firstName = null,
        string? lastName = null
    )
    {
        return new User(emailAddress, passwordHash, salt, avatarUrl, bio, firstName, lastName);
    }

    public void Edit(string avatarUrl, string bio, string firstName, string lastName)
    {
        AvatarUrl = avatarUrl;
        Bio = bio;
        FirstName = firstName;
        LastName = lastName;
        LastUpdateAt = DateTime.UtcNow;
    }
}