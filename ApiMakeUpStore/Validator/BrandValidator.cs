using ApiMakeUpStore.Models;
using FluentValidation;

namespace ApiMakeUpStore.Validator
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("name cannot be null");
            RuleFor(p => p.Country).NotEmpty().WithMessage("country cannot be null");

        }
    }
}
