using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Commands;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommandRequest, SaleCreateDto>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;

    }
    public async Task<SaleCreateDto> Handle(CreateSaleCommandRequest request, CancellationToken cancellationToken)
    {

        var sale = _mapper.Map<Sale>(request.SaleCreateDto);
        await _saleRepository.AddAsync(sale);
        var saleMapped = _mapper.Map<SaleCreateDto>(sale);
        return saleMapped;

    }
}
