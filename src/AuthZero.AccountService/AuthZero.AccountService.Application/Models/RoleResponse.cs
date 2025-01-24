
namespace AuthZero.AccountService.Application.Models;

public class RoleResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public RoleResponse(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public RoleResponse()
    {
    }
}