using FluentValidation;
using Liquid.API.Features.Users.Commands;

namespace Liquid.API.Features.Users.Validator
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(75);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(75);
            RuleFor(x => x.DateOfBirth).NotNull().NotEmpty();
            RuleFor(x => x.Role).NotNull().NotEmpty().IsInEnum();
            RuleFor(x => x.Username).NotNull().NotEmpty().MaximumLength(75);
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Password and confirm password does not match");
            RuleFor(x => x.Active).NotNull();
        }
    }
}