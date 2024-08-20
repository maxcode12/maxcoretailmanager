namespace MaxCoRetailManager.Application.DTOs.InventoryDTO;

public class InventoryCreateDto
{
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public int Quantity { get; set; }
    public decimal Cost { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
}
