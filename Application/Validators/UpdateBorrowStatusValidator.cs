using Domain;
using FluentValidation;
using LibraryManagementSystemAPI.Application.DTOs;

namespace LibraryManagementSystemAPI.Application.Validators
{
    public class UpdateBorrowStatusValidator : AbstractValidator<UpdateBorrowStatusDto>
    {
        public UpdateBorrowStatusValidator()
        {

            RuleFor(s => s.Status)
                .IsInEnum()
                .WithMessage("Invalid status value.");

            RuleFor(r => r.ReturnDate)
                .NotNull()
                .WithMessage("Return date is required when status is 'Returned'.")
                .When(x => x.Status == BorrowStatus.Returned);

            RuleFor(r => r.ReturnDate)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Return date cannot be in the future when marking as 'Returned'.")
                .When(x => x.Status == BorrowStatus.Returned && x.ReturnDate.HasValue);

            RuleFor(r => r.ReturnDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Return date must be in the future.")
                .When(x => x.ReturnDate.HasValue && x.Status != BorrowStatus.Returned);
        }
    }
}
