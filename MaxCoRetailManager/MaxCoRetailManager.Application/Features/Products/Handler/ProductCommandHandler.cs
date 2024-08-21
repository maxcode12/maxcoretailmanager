using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
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
    private readonly IMapper _mapper;

    public ProductCommandHandler(Contracts.Persistence.IUnitOfWork unitOfWork,
        IAuthRepository authenticate, IMapper mapper, IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _authenticate = authenticate;
        _inventoryRepository = inventoryRepository;
    }
    public async Task<ProductCreateDto> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        var modelProduct = request.ModelProduct;
        var userId = _authenticate.GetCurrentUserId();

        if (userId == null)
        {
            throw new Exception("Unauthorized access");
        }

        var productRepo = _unitOfWork.GetRepository<Product>();
        var categoryRepo = _unitOfWork.GetRepository<Category>();

        var category = await categoryRepo.GetAllAsync(c => c.UserId.ToString() == userId.ToString());


        var product = new Product
        {
            UserId = userId.ToString(),
            Name = modelProduct.Name,
            Description = modelProduct.Description,
            Price = modelProduct.Price,
            CategoryId = modelProduct.CategoryId,
            Sku = modelProduct.Sku,
            DeliveryTimeSpan = modelProduct.DeliveryTimeSpan,
            ImageUrl = modelProduct.ImageUrl,
            IsAvailable = modelProduct.IsAvailable,
            IsOnSale = modelProduct.IsOnSale,
            LocationId = modelProduct.LocationId,
            Inventories = modelProduct.Quantity > 0 ? new List<Inventory> { new Inventory { Quantity = modelProduct.Quantity } } : null

        };


        await productRepo.AddAsync(product);

        var productMapped = _mapper.Map<ProductCreateDto>(modelProduct);


        return productMapped;

    }
}
