
using AuthZero.AccountService.Domain.AggregatesModel.User;
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.AggregatesModel;


public class Role : AggregateRoot
{
    public string Name { get; set; }

    public string Description { get; set; }

    public List<User.User> Users { get; set; } = new();

    public Role(string name, string description)
    {
        Name = name;
        Description = description;
    }
}