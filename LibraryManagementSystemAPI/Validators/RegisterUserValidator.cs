using FluentValidation;
using System.Text.RegularExpressions;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
    {
        public RegisterUserValidator()
        {
            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters.")
                .MaximumLength(50).WithMessage("Username cannot exceed 50 characters.")
                .Matches("^[a-zA-Z0-9_.-]+$").WithMessage("Username can only contain letters, numbers, underscore, dot or hyphen.");

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(254).WithMessage("Email cannot exceed 254 characters.");

            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.")
                .Matches("(?=.*[a-z])").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("(?=.*[A-Z])").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("(?=.*\\d)").WithMessage("Password must contain at least one digit.")
                .Matches("(?=.*[^a-zA-Z0-9])").WithMessage("Password must contain at least one special character.");

            RuleFor(ph => ph.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .Must(p => string.IsNullOrWhiteSpace(p) || Regex.IsMatch(p, "^\\+?\\d{10,15}$"))
                .WithMessage("Phone number must be empty or a valid phone number with 10 to 15 digits and optional leading +");
        }
    }
}
