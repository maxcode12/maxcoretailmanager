using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Requests.Queries;

public class GetInventoryByIdQuery : IRequest<InventoryGetDto>
{
    public int Id { get; set; }
}
