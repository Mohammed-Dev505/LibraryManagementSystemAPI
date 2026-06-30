using FluentValidation;
using LibraryManagementSystemAPI.Application.DTOs;

namespace LibraryManagementSystemAPI.Application.Validators
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;


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
