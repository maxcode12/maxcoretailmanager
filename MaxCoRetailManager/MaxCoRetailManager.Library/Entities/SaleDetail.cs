using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class SaleDetail : Base
{
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
    public decimal? Tax { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public DateTime? SaleDate { get; set; }

    // Navigation properties
    public virtual Sale? Sale { get; set; }
    public virtual Product? Product { get; set; }


}
