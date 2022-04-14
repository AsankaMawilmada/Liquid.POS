using FluentValidation;
using Liquid.API.Features.Customers.Commands;

namespace Liquid.API.Features.Customers.Validators
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.Phone).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.AddressLine1).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.AddressLine2).MaximumLength(50);
            RuleFor(x => x.City).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.State).MaximumLength(50);
            RuleFor(x => x.PostalCode).NotNull().NotEmpty().MaximumLength(15);
        }
    }
}