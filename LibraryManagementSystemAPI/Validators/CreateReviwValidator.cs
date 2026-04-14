using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public sealed class CreateReviewValidator : AbstractValidator<CreateReviwDto>
    {
        public CreateReviewValidator()
        {

            RuleFor(b => b.BookId)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Invalid book ID. BookId must be 1 or greater.");

            RuleFor(c => c.Comment)
                .NotNull().WithMessage("Comment is required.")
                .Must(c => !string.IsNullOrWhiteSpace(c)).WithMessage("Comment cannot be only whitespace.")
                .MinimumLength(5).WithMessage("Comment must be at least 5 characters.")
                .MaximumLength(150).WithMessage("Comment cannot exceed 150 characters.");
        }
    }
}
