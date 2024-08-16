using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Handler;

public class GetSalesDetailsListHandler : IRequestHandler<GetSaleDetailsListQuery, IReadOnlyList<SaleDetailGetDto>>
{
    private readonly ISaleDetailRepository _saleDetailsRepository;
    private readonly IMapper _mapper;

    public GetSalesDetailsListHandler(ISaleDetailRepository saleDetailRepository, IMapper mapper)
    {
        _mapper = mapper;
        _saleDetailsRepository = saleDetailRepository;
    }
    public async Task<IReadOnlyList<SaleDetailGetDto>> Handle(GetSaleDetailsListQuery request, CancellationToken cancellationToken)
    {
        var saleDetails = await _saleDetailsRepository.GetAllAsync();
        var saleMap = _mapper.Map<IReadOnlyList<SaleDetailGetDto>>(saleDetails);
        return saleMap;
    }
}
