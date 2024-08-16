using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Handler;

public class GetSaleDetailsByIdHandler : IRequestHandler<GetSaleDetailsByIdQuery, SaleDetailGetDto>
{
    private readonly ISaleDetailRepository _saleDetailsRepository;
    private readonly IMapper _mapper;

    public GetSaleDetailsByIdHandler(ISaleDetailRepository saleDetailsRepository, IMapper mapper)
    {
        _saleDetailsRepository = saleDetailsRepository;
        _mapper = mapper;
    }

    public async Task<SaleDetailGetDto> Handle(GetSaleDetailsByIdQuery request, CancellationToken cancellationToken)
    {
        var saleDetails = await _saleDetailsRepository.GetAsync(request.Id);
        return _mapper.Map<SaleDetailGetDto>(saleDetails);
    }
}
