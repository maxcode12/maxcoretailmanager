using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, IReadOnlyList<ProductGetDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<ProductGetDto>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var allProducts = await _productRepository.GetAllAsync();
        var productsMapper = _mapper.Map<IReadOnlyList<ProductGetDto>>(allProducts);
        return productsMapper;
    }
}
