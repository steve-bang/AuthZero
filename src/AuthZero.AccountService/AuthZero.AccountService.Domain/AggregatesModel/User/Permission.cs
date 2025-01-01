
using AuthZero.AccountService.Domain.Common;

namespace AuthZero.AccountService.Domain.AggregatesModel;


public class Permission : AggregateRoot
{
    public string Code { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public Permission(string code, string name, string description)
    {
        Code = code;
        Name = name;
        Description = description;
    }
}