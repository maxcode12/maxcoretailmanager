using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class ProductCommandHandler : IRequestHandler<ProductCommand, ProductCreateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public ProductCommandHandler(IProductRepository productRepository, IMapper mapper,
        IInventoryRepository inventoryRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _inventoryRepository = inventoryRepository;
    }
    public async Task<ProductCreateDto> Handle(ProductCommand request, CancellationToken cancellationToken)
    {


        //create product
        var newProduct = _mapper.Map<Product>(request.ProductCreateDto);
        await _productRepository.AddAsync(newProduct);


        // Map the saved product back to ProductCreateDto for the return value

        var productMapped = _mapper.Map<ProductCreateDto>(newProduct);
        return productMapped;

    }
}
