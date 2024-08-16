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
    private readonly IMapper _mapper;

    public ProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductCreateDto> Handle(ProductCommand request, CancellationToken cancellationToken)
    {
        //var validator = new ProductCreateValidator();
        //var validationResult = validator.Validate(request.ProductCreateDto);
        //if (validationResult != null)
        //{
        //    throw new ValidationException(validationResult.ToString());
        //}

        var product = _mapper.Map<Product>(request.ProductCreateDto);
        await _productRepository.AddAsync(product);
        var productMapped = _mapper.Map<ProductCreateDto>(product);
        return productMapped;

    }
}
