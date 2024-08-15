using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.InventoryDTO;

public class InventoryGetDto : BaseDto
{

    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}
