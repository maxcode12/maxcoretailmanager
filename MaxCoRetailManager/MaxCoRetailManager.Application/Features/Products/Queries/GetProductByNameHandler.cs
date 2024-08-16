using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

internal class GetProductByNameHandler : IRequestHandler<GetProductByNameRequest, ProductGetDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByNameHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<ProductGetDto> Handle(GetProductByNameRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Name);
        var productMapper = _mapper.Map<ProductGetDto>(product);
        return productMapper;
    }
}
