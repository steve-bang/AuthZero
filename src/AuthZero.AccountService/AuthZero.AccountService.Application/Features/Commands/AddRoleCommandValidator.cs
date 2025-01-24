
using FluentValidation;

namespace AuthZero.AccountService.Application.Features.Commands;

public class AddRoleCommandValidator : AbstractValidator<AddRoleCommand>
{
    public AddRoleCommandValidator()
    {
        RuleFor(data => data.Name)
            .NotEmpty()
            .WithMessage("The name can't be empty.")
            .WithErrorCode("role.name.required");

        RuleFor(data => data.Description)
            .NotEmpty()
            .WithMessage("The description can't be empty.")
            .WithErrorCode("role.description.required");
    }
}