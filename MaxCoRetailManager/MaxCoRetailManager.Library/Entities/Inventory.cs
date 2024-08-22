using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Inventory : Base
{
    public int ProductId { get; set; }
    public int LocationId { get; set; }

    public int SaleId { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quantity { get; set; }
    public string UserId { get; set; } = string.Empty;

    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Product Product { get; set; }
    public virtual Location Location { get; set; }
    public virtual Sale Sale { get; set; }

    public virtual SaleDetail SaleDetail { get; set; }

}
