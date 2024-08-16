using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.SaleDTO;

public class SaleUpdateDto : BaseDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string SaleBy { get; set; } = string.Empty;
}
