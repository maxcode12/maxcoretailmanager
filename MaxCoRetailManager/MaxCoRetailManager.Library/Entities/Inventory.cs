using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Inventory : Base
{
    public int ProductId { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    public Product Product { get; set; }
}
