using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Inventory : Base
{
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public decimal PurchasePrice { get; set; }
    public int Quantity { get; set; }
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = new();
    public DateTime PurchaseDate { get; set; } = DateTime.UtcNow;
    public Product Product { get; set; } = new();
    public Location Location { get; set; } = new();

}
