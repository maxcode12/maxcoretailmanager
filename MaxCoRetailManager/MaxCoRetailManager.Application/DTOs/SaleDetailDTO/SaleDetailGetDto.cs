using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.SaleDetailDTO;

public class SaleDetailGetDto : BaseDto
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
}
