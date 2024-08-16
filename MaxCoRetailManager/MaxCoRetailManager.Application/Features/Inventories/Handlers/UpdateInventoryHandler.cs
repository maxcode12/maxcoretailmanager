using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class UpdateInventoryHandler : IRequestHandler<UpdateInventoryCommand, InventoryUpdateDto>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public UpdateInventoryHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }
    public async Task<InventoryUpdateDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        var inventory = _mapper.Map<Inventory>(request.Inventory); // Map the request to the entity
        await _inventoryRepository.UpdateAsync(inventory); // Update the entity
        return _mapper.Map<InventoryUpdateDto>(inventory); // Map the entity to the response
    }
}
