using FluentValidation;
using Trining_RESTApi.DTOs;
using System;
using System.Linq;

namespace LibraryManagementSystemAPI.Validators
{
    public class CreateBookValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookValidator()
        {

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(2, 150).WithMessage("Title must be between 2 and 150 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.")
                .When(x => !string.IsNullOrWhiteSpace(x.Description));

            RuleFor(x => x.ISBN)
                .Cascade(CascadeMode.Stop)
                .Must(isbn => string.IsNullOrWhiteSpace(isbn) || IsValidIsbn(isbn))
                .WithMessage("ISBN must be either 10 or 13 digits (hyphens allowed).");

            RuleFor(x => x.PublishedDate)
                .NotEmpty().WithMessage("PublishedDate is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("PublishedDate cannot be in the future.");

            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("Invalid author ID.");

            RuleFor(x => x.CopiesAvailable)
                .GreaterThanOrEqualTo(0).WithMessage("CopiesAvailable must be zero or a positive integer.");
        }

        private static bool IsValidIsbn(string isbn)
        {
            var digits = new string(isbn.Where(char.IsDigit).ToArray());
            return digits.Length == 10 || digits.Length == 13;
        }
    }
}
