using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(i => i.Id)
                .GreaterThan(0).WithMessage("Invalid book ID.");

            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Must(t => !string.IsNullOrWhiteSpace(t) && t.Trim().Length >= 2)
                    .WithMessage("Title must be at least 2 characters.")
                .Must(t => t == null || t.Trim().Length <= 150)
                    .WithMessage("Title cannot exceed 150 characters.");

            RuleFor(d => d.Description)
                .Must(d => string.IsNullOrWhiteSpace(d) || d.Trim().Length <= 500)
                .WithMessage("Description cannot exceed 500 characters.");

            RuleFor(c => c.CopiesAvailable)
                .GreaterThanOrEqualTo(0).WithMessage("Copies Available must be zero or a positive integer.");
        }
    }
}
