namespace MaxCoRetailManager.Application.DTOs.InventoryDTO;

public class InventoryCreateDto
{
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int SaleId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
