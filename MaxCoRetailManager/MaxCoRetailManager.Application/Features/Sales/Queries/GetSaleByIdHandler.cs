﻿using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.DTOs.SaleDTO;
using MaxCoRetailManager.Application.Features.Sales.Requests;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Queries;

public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdRequest, SaleGetDto>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    public GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }
    public async Task<SaleGetDto> Handle(GetSaleByIdRequest request, CancellationToken cancellationToken)
    {
        var saleMapper = _mapper.Map<SaleGetDto>(request.Id);
        await _saleRepository.GetAsync(request.Id);

        return saleMapper;
    }
}
