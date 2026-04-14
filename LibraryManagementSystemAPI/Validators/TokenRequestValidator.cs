using FluentValidation;
using LibraryManagementSystemAPI.Data.Models;

namespace LibraryManagementSystemAPI.Validators
{
    public class TokenRequestValidator : AbstractValidator<TokenRequestModel>
    {
        private const int PasswordMinLength = 6;
        private const int PasswordMaxLength = 128;
        private const int EmailMaxLength = 254;

        public TokenRequestValidator()
        {
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(EmailMaxLength).WithMessage($"Email must be at most {EmailMaxLength} characters.")
                .WithName("Email");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(PasswordMinLength).WithMessage($"Password must be at least {PasswordMinLength} characters.")
                .MaximumLength(PasswordMaxLength).WithMessage($"Password must be at most {PasswordMaxLength} characters.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("\\d").WithMessage("Password must contain at least one digit.")
                .Matches("[\\W_]").WithMessage("Password must contain at least one special character.")
                .WithName("Password");
        }
    }
}
