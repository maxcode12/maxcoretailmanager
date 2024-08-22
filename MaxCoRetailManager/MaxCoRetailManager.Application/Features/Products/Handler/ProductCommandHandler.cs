using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class ProductCommandHandler : IRequestHandler<ProductCommand, ProductCreateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly Contracts.Persistence.IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authenticate;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IMapper _mapper;

    public ProductCommandHandler(Contracts.Persistence.IUnitOfWork unitOfWork,
        IAuthRepository authenticate, IMapper mapper,
        IInventoryRepository inventoryRepository, ILocationRepository locationRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _authenticate = authenticate;
        _inventoryRepository = inventoryRepository;
        _locationRepository = locationRepository;
    }
    public async Task<ProductCreateDto> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var updateInventory = new InventoryUpdateDto
        {
            UserId = request.ModelProduct.UserId,
            Quantity = request.ModelProduct.Quantity
        };

        var userId = _authenticate.GetCurrentUserId();
        var findLocation = await _locationRepository.GetAsync(request.ModelProduct.LocationId);
        var findCategory = await _unitOfWork.GetRepository<Category>().GetAsync(request.ModelProduct.CategoryId);
        var findProduct = await _productRepository.GetAsync(request.ModelProduct.Sku);

        var findSale = _unitOfWork.GetRepository<Sale>().GetAllAsync(s => s.UserId == userId.ToString());

        var purchasePrice = request.ModelProduct.Price;
        var productPrice = request.ModelProduct.Price;

        var product = new Product
        {
            Name = request.ModelProduct.Name,
            Description = request.ModelProduct.Description,
            Sku = request.ModelProduct.Sku,
            Price = productPrice,
            DeliveryTimeSpan = request.ModelProduct.DeliveryTimeSpan,
            ImageUrl = request.ModelProduct.ImageUrl,
            IsAvailable = request.ModelProduct.IsAvailable,
            IsOnSale = request.ModelProduct.IsOnSale,
            IsSellOnPOS = request.ModelProduct.IsSellOnPOS,
            IsSellOnline = request.ModelProduct.IsSellOnline,
            CategoryId = findCategory.Id,
            UserId = userId.ToString(),
            LocationId = findLocation.Id,
            Inventories = request.ModelProduct.Inventories.Select(
                inv => new Inventory
                {
                    ProductId = findProduct.Id,
                    Quantity = inv.Quantity,

                }).ToList()


        };

        var productMapped = _mapper.Map<ProductCreateDto>(product);

        await _productRepository.AddAsync(product);



        return productMapped;

    }
}
