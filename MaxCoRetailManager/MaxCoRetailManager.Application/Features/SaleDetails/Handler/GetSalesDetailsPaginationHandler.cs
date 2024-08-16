using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Handler;

public class GetSalesDetailsPaginationHandler : IRequestHandler<GetSalesDetailPaginationQuery, Pagination<SaleDetailGetDto>>
{
    private readonly ISaleDetailRepository _saleDetailRepository;
    private readonly IMapper _mapper;

    public GetSalesDetailsPaginationHandler(ISaleDetailRepository saleDetailRepository, IMapper mapper)
    {
        _saleDetailRepository = saleDetailRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<SaleDetailGetDto>> Handle(GetSalesDetailPaginationQuery request, CancellationToken cancellationToken)
    {
        var saleDetails = await _saleDetailRepository.GetAllPagination(request.CatalogSpecParams);
        var saleMap = _mapper.Map<Pagination<SaleDetailGetDto>>(saleDetails);
        return saleMap;
    }
}
