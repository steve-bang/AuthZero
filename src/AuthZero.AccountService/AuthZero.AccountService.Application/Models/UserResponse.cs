
namespace AuthZero.AccountService.Application.Models;

public class UserResponse
{
    public Guid Id { get; set; }

    public string EmailAddress { get; set; }

    public string? AvatarUrl { get; set; }

    public string? Bio { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }



    public UserResponse(Guid id, string emailAddress, string? avatarUrl, string? bio, string? firstName, string? lastName)
    {
        Id = id;
        EmailAddress = emailAddress;
        AvatarUrl = avatarUrl;
        Bio = bio;
        FirstName = firstName;
        LastName = lastName;
    }

    public UserResponse(User user)
    {
        Id = user.Id;
        EmailAddress = user.EmailAddress;
        AvatarUrl = user.AvatarUrl;
        Bio = user.Bio;
        FirstName = user.FirstName;
        LastName = user.LastName;
    }

    public UserResponse()
    {
    }
}
