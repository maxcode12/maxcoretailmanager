using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Handlers;

internal class GetSaleByDateHandler : IRequestHandler<GetSaleByDateQuery, SaleGetDto>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public GetSaleByDateHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _mapper = mapper;
        _saleRepository = saleRepository;

    }
    public async Task<SaleGetDto> Handle(GetSaleByDateQuery request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetAsync(request.Date);
        var saleMapper = _mapper.Map<SaleGetDto>(sale);

        return saleMapper;
    }
}
