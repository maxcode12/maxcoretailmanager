using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Application.DTOs.SaleDTO;

public class SaleCreateDto : Base
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime SaleDate { get; set; }
    public string SaleBy { get; set; }


}
