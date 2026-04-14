using FluentValidation;
using Trining_RESTApi.DTOs;
using System;
using Trining_RESTApi.Data.Models;

namespace LibraryManagementSystemAPI.Validators
{
    public class UpdateBorrowStatusValidator : AbstractValidator<UpdateBorrowStatusDto>
    {
        public UpdateBorrowStatusValidator()
        {

            RuleFor(i => i.Id)
                .GreaterThan(0)
                .WithMessage("Invalid borrow ID.");

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
