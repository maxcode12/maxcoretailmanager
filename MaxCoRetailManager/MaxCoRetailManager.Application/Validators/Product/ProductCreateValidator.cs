using FluentValidation;
using MaxCoRetailManager.Application.DTOs.ProductDTO;

namespace MaxCoRetailManager.Application.Validators.Product;

public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is TooLong")
            ;
        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Description is required");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0")
            .ScalePrecision(2, 7).WithMessage("Enter the right deciaml digits");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category Id must be greater than 0")
            ;

    }
}

