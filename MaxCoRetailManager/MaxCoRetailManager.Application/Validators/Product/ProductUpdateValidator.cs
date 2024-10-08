﻿using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;

namespace MaxCoRetailManager.Application.Validators.Product;

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    private readonly IProductRepository _productRepository;
    public ProductUpdateValidator(IProductRepository productRepository)
    {
        _productRepository = productRepository;
        RuleFor(x => x.Id)
            .Cascade(CascadeMode.Stop)
            .GreaterThan(0).WithMessage("Id must be greater than 0")
            .MustAsync(async (id, token) =>
            {
                return await _productRepository.IsExist(id);

            }).WithMessage("Product not found");


        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .NotNull().WithMessage("Name is required")
            .MaximumLength(100).WithMessage("Name is TooLong");

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500)
            .WithMessage("Description is required");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("Category Id must be greater than 0")
            .MustAsync(async (id, token) =>
            {
                return await _productRepository.IsExist(id);

            }).WithMessage("Category not found");
    }
}
