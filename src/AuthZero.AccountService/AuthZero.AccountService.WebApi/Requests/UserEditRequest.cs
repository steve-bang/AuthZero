
namespace AuthZero.AccountService.WebApi.Models;

public record UserEditRequest(
    string AvatarUrl,
    string Bio,
    string FirstName,
    string LastName
);