using CoreMarket.DTOs;
using FluentValidation;

namespace CoreMarket.Validators;

public class ProductDTOValidator : AbstractValidator<ProductDTO>
{
    public ProductDTOValidator()
    {
        

        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("From FV:Please enter a valid name");

        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThan(double.MaxValue)
            .WithMessage("From FV:Please enter a valid value for price");

        RuleFor(p => p.Quantity)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThan(int.MaxValue)
            .WithMessage("From FV:Please enter a valid value for quantity");

        RuleFor(p=>p.BrandId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("From FV:Please enter a valid BrandId");

    }
}
