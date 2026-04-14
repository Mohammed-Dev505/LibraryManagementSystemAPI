using FluentValidation;
using Trining_RESTApi.DTOs;

namespace LibraryManagementSystemAPI.Validators
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleValidator()
        {

            RuleFor(r => r.RoleName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Role name is required.")
                .MinimumLength(3).WithMessage("Role name must be at least {MinLength} characters.")
                .MaximumLength(50).WithMessage("Role name must not exceed {MaxLength} characters.")
                .Matches("^[\\p{L}\\p{M}\\d\\-\\s]+$").WithMessage("Role name contains invalid characters.");
        }
    }
}
