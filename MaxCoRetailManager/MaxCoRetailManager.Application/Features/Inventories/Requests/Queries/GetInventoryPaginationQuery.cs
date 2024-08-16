using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MaxCoRetailManager.Application.Specs;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;

public class GetInventoryPaginationQuery : IRequest<Pagination<InventoryGetDto>>
{
    public CatalogSpecParams CatalogSpecParams { get; set; } = new();
}
