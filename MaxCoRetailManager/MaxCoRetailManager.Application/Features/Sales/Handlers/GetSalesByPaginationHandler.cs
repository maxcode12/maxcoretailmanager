using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Handlers;

public class GetSalesByPaginationHandler : IRequestHandler<GetSalesPaginationQuery, Pagination<SaleGetDto>>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSalesByPaginationHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<Pagination<SaleGetDto>> Handle(GetSalesPaginationQuery request, CancellationToken cancellationToken)
    {

        var salePagination = await _saleRepository.GetAllPagination(request.CatalogSpecParams);
        var saleMapper = _mapper.Map<Pagination<SaleGetDto>>(salePagination);

        return saleMapper;

    }
}
