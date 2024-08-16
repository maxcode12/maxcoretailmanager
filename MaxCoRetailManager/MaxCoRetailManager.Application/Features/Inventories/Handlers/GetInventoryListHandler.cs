using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryListHandler : IRequestHandler<GetInventoryListQuery, IReadOnlyList<InventoryGetDto>>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public GetInventoryListHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<InventoryGetDto>> Handle(GetInventoryListQuery request, CancellationToken cancellationToken)
    {
        var inventories = await _inventoryRepository.GetAllAsync();
        var inventoryDto = _mapper.Map<IReadOnlyList<InventoryGetDto>>(inventories); // Mapping the inventory to the InventoryGetDto
        return inventoryDto;
    }
}
