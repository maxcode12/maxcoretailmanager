using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MaxCoRetailManager.Core.Entities;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryByIdHandler : IRequestHandler<GetInventoryByIdQuery, InventoryGetDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetInventoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<InventoryGetDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        var inventory = await _unitOfWork.GetRepository<Inventory>().GetAsync(request.Id);
        var inventoryDto = _mapper.Map<InventoryGetDto>(inventory); // Mapping the inventory to the InventoryGetDto

        return inventoryDto;
    }
}
