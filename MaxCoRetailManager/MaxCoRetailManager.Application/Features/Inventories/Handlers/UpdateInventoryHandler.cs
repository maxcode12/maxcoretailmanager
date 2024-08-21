using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryUpdateDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<InventoryUpdateDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = _mapper.Map<Inventory>(request.Inventory); // Map the request to the entity
        await _unitOfWork.GetRepository<Inventory>().UpdateAsync(inventory); // Update the entity
        return _mapper.Map<InventoryUpdateDto>(inventory); // Map the entity to the response
    }
}
