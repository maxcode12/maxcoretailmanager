using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryListHandler : IRequestHandler<GetInventoryListQuery, IReadOnlyList<InventoryGetDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInventoryListHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<IReadOnlyList<InventoryGetDto>> Handle(GetInventoryListQuery request, CancellationToken cancellationToken)
    {
        var inventories = await _unitOfWork.GetRepository<Inventory>().GetAllAsync();
        var inventoryDto = _mapper.Map<IReadOnlyList<InventoryGetDto>>(inventories); // Mapping the inventory to the InventoryGetDto
        return inventoryDto;
    }
}
