using FluentValidation;
using LibraryManagementSystemAPI.Application.DTOs;

namespace LibraryManagementSystemAPI.Application.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidator()
        {

            RuleFor(n => n.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage("Name must be at least 3 characters.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(b => b.Biography)
                .MaximumLength(500).WithMessage("Biography cannot exceed 500 characters.")
                .When(b => !string.IsNullOrWhiteSpace(b.Biography));
        }
    }
}
