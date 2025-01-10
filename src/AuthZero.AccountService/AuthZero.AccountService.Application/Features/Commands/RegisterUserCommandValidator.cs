
using FluentValidation;

namespace AuthZero.AccountService.Application.Features.Commands;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        // Rule for Email Address
        RuleFor(data => data.EmailAddress)
            .NotEmpty()
                .WithErrorCode(UserError.Codes.EmailRequired)
                .WithMessage(UserError.Messages.EmailRequired)
            .EmailAddress()
                .WithErrorCode(UserError.Codes.EmailInvalidFormat)
                .WithMessage(UserError.Messages.EmailInvalidFormat);


        // Rule for Password
        RuleFor(x => x.Password)
            .NotEmpty()
                .WithErrorCode(UserError.Codes.PasswordRequired)
                .WithMessage(UserError.Messages.PasswordRequired)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d@#$%^&*!]{8,}$")
                .WithMessage(UserError.Messages.PasswordInvalid)
                .WithErrorCode(UserError.Codes.PasswordInvalid)
            .Equal(x => x.PasswordConfirmation)
                .WithMessage(UserError.Messages.PasswordMismatch)
                .WithErrorCode(UserError.Codes.PasswordMismatch);
    }
}