using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorValidator()
        {
            RuleFor(i => i.Id)
                .GreaterThan(0)
                .WithMessage("Invalid author ID.");

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
