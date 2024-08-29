using FluentValidation;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;

namespace MaxCoRetailManager.Application.Validators.Product;

public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAuthRepository _authRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IInventoryRepository _inventoryRepository;
    public ProductCreateValidator(
        IAuthRepository authRepository,
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        ILocationRepository locationRepository,
        IInventoryRepository inventoryRepository)
    {

        _authRepository = authRepository;
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _locationRepository = locationRepository;
        _inventoryRepository = inventoryRepository;

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
            .GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("Sku is required")
            .NotNull().WithMessage("Sku is required")
            .MaximumLength(50).WithMessage("Sku is TooLong");

        RuleFor(x => x.DeliveryTimeSpan)
            .NotEmpty().WithMessage("Delivery Time Span is required")
            .NotNull().WithMessage("Delivery Time Span is required")
            .MaximumLength(50).WithMessage("Delivery Time Span is TooLong");

        RuleFor(x => x.ImageUrl)
            .NotEmpty().WithMessage("Image Url is required")
            .NotNull().WithMessage("Image Url is required")
            .MaximumLength(500).WithMessage("Image Url is TooLong");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0");

        RuleFor(x => x.IsAvailable)
            .Must(RuleFor => RuleFor == true)
            .When(x => x.IsSellOnline == true)
            .When(x => x.IsSellOnPOS == true)
            .WithMessage("Is Available must be true if Is Sell Online is true")
            .NotEmpty().WithMessage("Is Available is required")
            .NotNull().WithMessage("Is Available cannot be null or empty");

        RuleFor(x => x.IsAvailable)
            .Must(RuleFor => RuleFor == false)
            .When(x => x.IsSellOnPOS == false)
            .When(x => x.IsSellOnline == false)
            .WithMessage("Is Available must be false if Is Sell Online is false")
            .WithMessage("Is Available must be false if Is Sell On POS is false")
            .NotEmpty().WithMessage("Is Available is required")
            .NotNull().WithMessage("Is Available cannot be null or empty");

        RuleFor(x => x.IsOnSale)
            .NotEmpty().WithMessage("Is On Sale is required")
            .NotNull().WithMessage("Is On Sale cannot be null or empty");

        RuleFor(x => x.CategoryId)
            .MustAsync(async (id, token) =>
            {
                var category = await _categoryRepository.GetAsync(id);
                return category != null;
            }).WithMessage("Category does not exist")
            .GreaterThan(0).WithMessage("Category Id must be greater than 0");

        RuleFor(x => x.LocationId)
            .MustAsync(async (id, token) =>
            {
                var location = await _locationRepository.GetAsync(id);
                return location != null;
            }).WithMessage("Location does not exist")
            .GreaterThan(0).WithMessage("Location Id must be greater than 0");

        RuleFor(x => x.UserId)
            .MustAsync(async (id, token) =>
            {
                var user = await _authRepository.GetUserId(id);
                return user != null;
            }).WithMessage("User does not exist")
            .NotEmpty().WithMessage("User Id is required");


    }
}

