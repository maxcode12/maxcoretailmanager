using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;

namespace MaxCoRetailManager.Application.Validators.Product;

public class ProductDeleteValidator : AbstractValidator<ProductDeleteDto>
{
    private readonly IProductRepository _productRepository;

    public ProductDeleteValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Id must be greater than 0")
            .MustAsync(async (id, cancellation) =>
            {
                return await _productRepository.IsExist(id);

            }).WithMessage("Product not found");
    }
}
