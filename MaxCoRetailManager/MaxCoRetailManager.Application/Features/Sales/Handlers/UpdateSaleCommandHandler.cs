using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Sales;
using MaxCoRetailManager.Application.Features.Sales.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Sales.Handlers;


public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, Unit>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var saleToUpdate = await _saleRepository.GetAsync(request.SaleUpdateDto.Id);

        if (saleToUpdate == null)
        {
            throw new ApplicationException($"Sale with id {request.SaleUpdateDto.Id} not found.");
        }

        var sale = _mapper.Map<Sale>(request.SaleUpdateDto);

        await _saleRepository.UpdateAsync(sale);

        return Unit.Value;
    }
}
