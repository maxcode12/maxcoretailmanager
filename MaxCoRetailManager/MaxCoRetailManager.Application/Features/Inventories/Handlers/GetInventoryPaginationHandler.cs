using AutoMapper;
using MaxCoRetailManager.Application.Contracts.Persistence.Products;
using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Handlers;

public class GetInventoryPaginationHandler : IRequestHandler<GetInventoryPaginationQuery, Pagination<InventoryGetDto>>
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IMapper _mapper;

    public GetInventoryPaginationHandler(IInventoryRepository inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<InventoryGetDto>> Handle(GetInventoryPaginationQuery request, CancellationToken cancellationToken)
    {
        var spec = await _inventoryRepository.GetAllPagination(request.CatalogSpecParams);
        var specMapper = _mapper.Map<Pagination<InventoryGetDto>>(spec); // Mapping the spec to the DTO

        return specMapper;

    }
}
