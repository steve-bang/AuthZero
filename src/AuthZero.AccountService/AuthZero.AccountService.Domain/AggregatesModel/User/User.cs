
using AuthZero.AccountService.Domain.Common;
using AuthZero.AccountService.Domain.Events;

namespace AuthZero.AccountService.Domain.AggregatesModel.User;

/// <summary>
/// This class represents a user in the system.
/// </summary>
public class User : AggregateRoot
{
    /// <summary>
    /// The roles of the user.
    /// </summary>
    private List<Role> _roles = new();

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

    public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

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

        // Add the UserRegisterLoginEvent to the domain events.
        AddEvent(new UserRegisterEvent(this));
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
        var user = new User(emailAddress, passwordHash, salt, avatarUrl, bio, firstName, lastName);

        return user;
    }

    public void Edit(string avatarUrl, string bio, string firstName, string lastName)
    {
        AvatarUrl = avatarUrl;
        Bio = bio;
        FirstName = firstName;
        LastName = lastName;
        LastUpdateAt = DateTime.UtcNow;
    }

    public void AssignRole(Role role)
    {
        if ( !_roles.Any(r => r.Id == role.Id) )
        {
            _roles.Add(role);
        }
    }

    public void AssignRole(IEnumerable<Role> roles)
    {
        foreach (var role in roles)
        {
            AssignRole(role);
        }
    }

    public void RevokeRole(Role role)
    {
        _roles.Remove(role);
    }
}