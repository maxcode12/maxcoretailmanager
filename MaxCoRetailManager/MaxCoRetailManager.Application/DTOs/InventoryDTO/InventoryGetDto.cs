using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.InventoryDTO;

public class InventoryGetDto : BaseDto
{

    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int SaleId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    //warehouse name
    public string LocationName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; }
}
