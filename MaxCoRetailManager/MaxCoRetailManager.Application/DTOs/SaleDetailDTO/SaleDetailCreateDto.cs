using MaxCoRetailManager.Core.Entities;

namespace MaxCoRetailManager.Application.DTOs.SaleDetailDTO;

public class SaleDetailCreateDto
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Tax { get; set; }
    public DateTime SaleDate { get; set; }
    public Sale Sale { get; set; } = new();
    public Product Product { get; set; } = new();
}
