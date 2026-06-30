using FluentValidation;
using LibraryManagementSystemAPI.Application.DTOs;

namespace LibraryManagementSystemAPI.Application.Validators
{
    public class CreateBorrowValidator : AbstractValidator<CreateBorrowDto>
    {
        public CreateBorrowValidator()
        {

            RuleFor(d => d.DueDate)
                .NotEqual(default(DateTime)).WithMessage("DueDate is required.")
                .Must(d => d.ToUniversalTime() > DateTime.UtcNow)
                .WithMessage("DueDate must be in the future.");
        }
    }
}
