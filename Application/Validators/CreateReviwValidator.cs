using FluentValidation;
using LibraryManagementSystemAPI.Application.DTOs;

namespace LibraryManagementSystemAPI.Application.Validators
{
    public sealed class CreateReviewValidator : AbstractValidator<CreateReviwDto>
    {
        public CreateReviewValidator()
        {

            RuleFor(c => c.Comment)
                .NotNull().WithMessage("Comment is required.")
                .Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("Comment cannot be only whitespace.")
                .MinimumLength(5).WithMessage("Comment must be at least 5 characters.")
                .MaximumLength(150).WithMessage("Comment cannot exceed 150 characters.");
        }
    }
}
