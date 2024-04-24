using CoreMarket.Core.DTO;
using FluentValidation;

namespace CoreMarket.Core.Helpers;

public class ProductDTOValidationHelper : AbstractValidator<ProductDTO>
{
    public ProductDTOValidationHelper()
    {
        

        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter a valid name");

        RuleFor(p => p.Price)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThan(double.MaxValue)
            .WithMessage("Please enter a valid value for price");

        RuleFor(p => p.Quantity)
            .NotNull()
            .GreaterThanOrEqualTo(0)
            .LessThan(int.MaxValue)
            .WithMessage("Please enter a valid value for quantity");

        RuleFor(p=>p.BrandId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Please enter a valid BrandId");

    }
}
