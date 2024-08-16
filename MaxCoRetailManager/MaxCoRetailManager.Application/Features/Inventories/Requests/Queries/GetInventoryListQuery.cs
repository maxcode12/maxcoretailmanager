using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;

public class GetInventoryListQuery : IRequest<IReadOnlyList<InventoryGetDto>>
{
}

