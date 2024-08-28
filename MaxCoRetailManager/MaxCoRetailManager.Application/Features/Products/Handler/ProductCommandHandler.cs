using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Categories;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class ProductCommandHandler : IRequestHandler<ProductCommand, ProductCreateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAuthRepository _authenticate;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public ProductCommandHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository,
        IAuthRepository authenticate,
        IMapper mapper,
        IInventoryRepository inventoryRepository,
        ILocationRepository locationRepository,
        ISaleRepository saleRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
        _authenticate = authenticate ?? throw new ArgumentNullException(nameof(authenticate));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
        _locationRepository = locationRepository ?? throw new ArgumentNullException(nameof(locationRepository));
        _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
    }

    public async Task<ProductCreateDto> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _authenticate.GetCurrentUserId();
        var userId = request.ModelProduct.UserId = currentUser.ToString();

        if (request.ModelProduct == null)
        {
            throw new ArgumentNullException(nameof(request.ModelProduct));
        }

        var findLocation = await _locationRepository.GetAllAsync(u => u.UserId == userId);
        var locationId = findLocation.FirstOrDefault(x => x.Id == request.ModelProduct.LocationId);
        if (locationId == null)
        {
            throw new Exception("Location not found");
        }

        var findCategory = await _categoryRepository.GetAllAsync(fc => fc.UserId == userId);
        var categoryId = findCategory.FirstOrDefault(x => x.Id == request.ModelProduct.CategoryId);
        if (categoryId == null)
        {
            throw new Exception("Category not found");
        }

        var findProductId = await _productRepository.GetAllAsync(p => p.Id == request.ModelProduct.Id);
        if (findProductId != null)
        {
            throw new Exception("Product already exists");
        }

        var product = new Product
        {
            Name = request.ModelProduct.Name,
            Description = request.ModelProduct.Description,
            Price = request.ModelProduct.Price,
            CategoryId = request.ModelProduct.CategoryId,
            LocationId = request.ModelProduct.LocationId,
            Sku = request.ModelProduct.Sku,
            DeliveryTimeSpan = request.ModelProduct.DeliveryTimeSpan,
            ImageUrl = request.ModelProduct.ImageUrl,
            IsAvailable = request.ModelProduct.IsAvailable,
            IsOnSale = request.ModelProduct.IsOnSale,
            IsSellOnPOS = request.ModelProduct.IsSellOnPOS,
            IsSellOnline = request.ModelProduct.IsSellOnline,
            UserId = userId.ToString()
        };

        await _productRepository.AddAsync(product);

        var productMapped = _mapper.Map<ProductCreateDto>(product);

        var findProduct = await _productRepository.GetAllAsync();
        if (findProduct == null)
        {
            throw new Exception("Product not found");
        }

        var inventory = new Inventory
        {
            ProductId = product.Id,
            Quantity = request.ModelProduct.Quantity,
            LocationId = request.ModelProduct.LocationId,
            PurchaseDate = DateTime.Now,
            PurchasePrice = request.ModelProduct.Price,
            UserId = userId.ToString()
        };

        await _inventoryRepository.AddAsync(inventory);

        return productMapped;
    }
}
