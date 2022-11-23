using ApiMakeUpStore.Models;
using FluentValidation;

namespace ApiMakeUpStore.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("name cannot be null");
            RuleFor(p => p.Type).NotEmpty().WithMessage("type cannot be null");
            RuleFor(p => p.Price).NotEmpty().WithMessage("price cannot be null");
            RuleFor(p => p.BodyPart).NotEmpty().WithMessage("body part cannot be null");
            RuleFor(p => p.IdBrand).NotEmpty().WithMessage("brand cannot be null");
            RuleFor(p => p.Description).NotEmpty().WithMessage("description cannot be null");

        }
    }
}
