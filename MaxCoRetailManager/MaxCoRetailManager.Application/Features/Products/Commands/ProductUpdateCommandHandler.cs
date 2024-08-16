using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Validators.Product;
using MaxCoRetailManager.Core.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Application.Features.Products.Commands;

public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommandRequest, ProductUpdateDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductUpdateDto> Handle(ProductUpdateCommandRequest request, CancellationToken cancellationToken)
    {
        var validator = new ProductUpdateValidator(_productRepository);
        var validationResult = validator.Validate(request.ProductUpdateDto);
        if (validationResult != null)
        {
            throw new ValidationException(validationResult.ToString());
        }

        var product = _mapper.Map<Product>(request.ProductUpdateDto);
        await _productRepository.UpdateAsync(product);

        return _mapper.Map<ProductUpdateDto>(product);
    }
}
