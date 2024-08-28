using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Identity;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, IReadOnlyList<ProductGetDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IAuthRepository _authRepository;
    private readonly IInventoryRepository _inventoryRepository;

    private readonly IMapper _mapper;

    public GetProductsListHandler(
        IProductRepository productRepository,
        IMapper mapper,
        IAuthRepository authRepository,
        IInventoryRepository inventoryRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _authRepository = authRepository;
        _inventoryRepository = inventoryRepository;
    }
    public async Task<IReadOnlyList<ProductGetDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var currentUser = _authRepository.GetCurrentUserId();

        var allProducts = await _productRepository.GetAllAsync(product => product.UserId == currentUser.Value.ToString());

        var products = await _productRepository.GetAllAsync(product => product.UserId == currentUser.Value.ToString(),

            include: query => query
            .Include(product => product.Category)
            .Include(product => product.Location));

        var inventory = await _inventoryRepository.GetAllAsync(i => i.UserId == currentUser.Value.ToString(),

             include: query => query
             .Include(product => product.Product));



        var productDto = products.Select(product => new ProductGetDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Sku = product.Sku,
            Price = product.Price,
            DeliveryTimeSpan = product.DeliveryTimeSpan,
            ImageUrl = product.ImageUrl,
            IsAvailable = product.IsAvailable,
            IsOnSale = product.IsOnSale,
            IsSellOnPOS = product.IsSellOnPOS,
            IsSellOnline = product.IsSellOnline,
            CategoryId = product.CategoryId.Value,
            CategoryName = product.Category.Name,
            UserId = product.UserId,
            LocationId = product.LocationId,
            InventoryDtos = product.Inventories.Select(inventory => new InventoryGetDto
            {
                Id = inventory.Id,
                Quantity = inventory.Quantity,
                ProductId = inventory.ProductId,
                LocationId = inventory.LocationId,

            }).ToList()


        }).ToList();

        var productsMapper = _mapper.Map<IReadOnlyList<ProductGetDto>>(productDto);


        return productsMapper;
    }
}
