using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDto>
    {
        public UpdateReviewValidator()
        {
            RuleFor(i => i.Id)
                .GreaterThan(0)
                .WithMessage("Invalid review ID.");

            RuleFor(c => c.Comment)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Comment is required.")
                .Must(c => !string.IsNullOrWhiteSpace(c) && c.Trim().Length >= 10)
                    .WithMessage("Comment must be at least 10 characters (excluding leading/trailing whitespace).")
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

            RuleFor(r => r.Rating)
                .InclusiveBetween(1, 5)
                .WithMessage("Rating must be between 1 and 5.");
        }
    }
}
