
using AuthZero.Shared.Exceptions;

namespace AuthZero.AccountService.Domain.Exception;

public static class UserError
{

    private static readonly BadRequestException _emailAlreadyExists =
        new(Codes.EmailAlreadyExists, Messages.EmailAlreadyExists);

    public static BadRequestException EmailAlreadyExists => _emailAlreadyExists;

    public static class Codes
    {
        public const string EmailAlreadyExists = "User.EmailAddress.Exists";

        public const string EmailInvalidFormat = "User.EmailAddress.InvalidFormat";

        public const string EmailRequired = "User.EmailAddress.Required";

        public const string PasswordRequired = "User.Password.Required";

        /// <summary>
        /// This error code is used when the password and confirm password do not match.
        /// The message is <see cref="Messages.PasswordMismatch"/>
        /// </summary>
        public const string PasswordMismatch = "User.Password.PasswordMismatch";

        public const string PasswordInvalid = "User.Password.Invalid";
    }

    public static class Messages
    {
        public const string EmailAlreadyExists = "An account with the email already exists. Please try another email.";
        public const string EmailInvalidFormat = "The email address is invalid format.";
        public const string EmailRequired = "The email address must be not empty.";
        public const string PasswordRequired = "The password is must be not empty.";
        public const string PasswordMismatch = "The password and confirm password must be matched.";
        public const string PasswordInvalid = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, and one digit.";
    }
}