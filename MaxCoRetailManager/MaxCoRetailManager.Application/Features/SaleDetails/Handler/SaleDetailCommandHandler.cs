using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDetailDTO;
using MaxCoRetailManager.Application.Features.SaleDetails.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.SaleDetails.Handler;

public class SaleDetailCommandHandler : IRequestHandler<SaleDetailCommand, SaleDetailCreateDto>
{
    private readonly IMapper _mapper;
    private readonly ISaleDetailRepository _saleDetailRepository;

    public SaleDetailCommandHandler(ISaleDetailRepository saleDetailRepository, IMapper mapper)
    {
        _mapper = mapper;
        _saleDetailRepository = saleDetailRepository;
    }
    public async Task<SaleDetailCreateDto> Handle(SaleDetailCommand request, CancellationToken cancellationToken)
    {

        var saleDetail = _mapper.Map<SaleDetail>(request.SaleDetailCreateDto);
        if (saleDetail == null)
        {
            throw new ApplicationException("SaleDetail cannot be created");
        }
        await _saleDetailRepository.AddAsync(saleDetail);
        var saleDetailCreateDto = _mapper.Map<SaleDetailCreateDto>(saleDetail);
        return saleDetailCreateDto;
    }
}
