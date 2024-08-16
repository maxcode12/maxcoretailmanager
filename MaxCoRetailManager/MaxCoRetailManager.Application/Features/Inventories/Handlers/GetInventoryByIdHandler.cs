using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, InventoryGetDto>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public GetInventoryByIdHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }
    public async Task<InventoryGetDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var inventory = await _inventoryRepository.GetAsync(request.Id);
        var inventoryDto = _mapper.Map<InventoryGetDto>(inventory); // Mapping the inventory to the InventoryGetDto

        return inventoryDto;
    }
}
