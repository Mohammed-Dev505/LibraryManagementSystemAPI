using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorValidator()
        {
            RuleFor(a => a.Name)
                .Must(name => !string.IsNullOrWhiteSpace(name))
                    .WithMessage("Name is required.")
                .Must(name =>
                {
                    var length = (name ?? string.Empty).Trim().Length;
                    return length >= 3 && length <= 50;
                })
                    .WithMessage("Name must be between 3 and 50 characters.")
                .WithName("Author Name");

            RuleFor(a => a.Biography)
                .Must(bio => !string.IsNullOrWhiteSpace(bio))
                    .WithMessage("Biography is required.")
                .Must(bio => (bio ?? string.Empty).Trim().Length <= 500)
                    .WithMessage("Biography cannot exceed 500 characters.")
                .WithName("Biography");
        }
    }
}
