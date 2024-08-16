using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MaxCoRetailManager.Application.Features.Products.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Handler;

public class GetProductRequestByIdHandler : IRequestHandler<GetProductByIdQuery, ProductGetDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductRequestByIdHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductGetDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Id);

        return _mapper.Map<ProductGetDto>(product);
    }
}
