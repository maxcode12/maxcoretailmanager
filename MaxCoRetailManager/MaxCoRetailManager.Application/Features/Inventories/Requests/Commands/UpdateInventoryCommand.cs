using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;

public class UpdateInventoryCommand : IRequest<InventoryUpdateDto>
{
    public InventoryUpdateDto Inventory { get; set; } = new();
}
