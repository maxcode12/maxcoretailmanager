using MaxCoRetailManager.Application.DTOs.InventoryDTO;
using MediatR;

namespace MaxCoRetailManager.Application.Features.Inventories.Requests.Commands;

public class CreateInventoryCommand : IRequest<InventoryCreateDto>
{
    public InventoryCreateDto Inventory { get; set; } = new();
}
