using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.ProductDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Products.Queries;

public class GetProductRequestByIdHandler : IRequestHandler<GetProductRequestById, ProductGetDto>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductRequestByIdHandler(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }
    public async Task<ProductGetDto> Handle(GetProductRequestById request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetAsync(request.Id);

        return _mapper.Map<ProductGetDto>(product);
    }
}
