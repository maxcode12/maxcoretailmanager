using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductsListHandler : IRequestHandler<GetProductsListRequest, IReadOnlyList<ProductGetDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListHandler(IProductRepository productRepository, IMapper mapper)
    {
        this._productRepository = productRepository;
        this._mapper = mapper;
    }
    public async Task<IReadOnlyList<ProductGetDto>> Handle(GetProductsListRequest request, CancellationToken cancellationToken)
    {
        var allProducts = await _productRepository.GetAllAsync();
        return _mapper.Map<IReadOnlyList<ProductGetDto>>(allProducts);
    }
}
