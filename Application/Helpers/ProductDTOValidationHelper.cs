using Application.DTOs;
using FluentValidation;

namespace Application.Helpers;

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

        RuleFor(p=>p.FileSize)
            .GreaterThan(0)
            .LessThan(double.MaxValue)
            .WithMessage("Please enter a valid value for file size");

        RuleFor(p => p.Quantity)
            .GreaterThanOrEqualTo(0)
            .LessThan(int.MaxValue)
            .WithMessage("Please enter a valid value for quantity");

        RuleFor(p => p.Weight)
            .GreaterThan(0)
            .LessThan(double.MaxValue)
            .WithMessage("Please enter a valid value for weight");

        RuleFor(p=>p.BrandId)
            .NotNull()
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Please enter a valid BrandId");

    }
}
