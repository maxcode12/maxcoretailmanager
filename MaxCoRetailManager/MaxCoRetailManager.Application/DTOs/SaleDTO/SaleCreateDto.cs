using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.SaleDTO;

public class SaleCreateDto : BaseDto
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

    public string SaleBy { get; set; } = Guid.NewGuid().ToString();


    public decimal? SubTotal { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Total { get; set; }

    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public decimal? PurchasePrice { get; set; }





}
