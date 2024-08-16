using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class GetProductByPaginationHandler : IRequestHandler<GetProductByPaginationQuery, Pagination<ProductGetDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByPaginationHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<ProductGetDto>> Handle(GetProductByPaginationQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAllPagination(request.CatalogSpecParams);
        var productMapper = _mapper.Map<Pagination<ProductGetDto>>(product);

        return productMapper;
    }
}
