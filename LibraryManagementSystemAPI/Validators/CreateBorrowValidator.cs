using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class CreateBorrowValidator : AbstractValidator<CreateBorrowDto>
    {
        public CreateBorrowValidator()
        {
            RuleFor(b => b.BookId)
                .GreaterThan(0)
                .WithMessage("Invalid book ID.");

            RuleFor(d => d.DueDate)
                .NotEqual(default(DateTime)).WithMessage("DueDate is required.")
                .Must(d => d.ToUniversalTime() > DateTime.UtcNow)
                .WithMessage("DueDate must be in the future.");
        }
    }
}
