using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Queries;

internal class GetSalesListHandler : IRequestHandler<GetSalesListRequest, IReadOnlyList<SaleGetDto>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSalesListHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _saleRepository = saleRepository;

    }
    public async Task<IReadOnlyList<SaleGetDto>> Handle(GetSalesListRequest request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync();
        var salesMapper = _mapper.Map<IReadOnlyList<SaleGetDto>>(sales);
        return salesMapper;
    }
}
