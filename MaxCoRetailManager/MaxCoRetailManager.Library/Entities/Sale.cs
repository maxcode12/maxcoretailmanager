using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Sale : Base
{
    public int ProductId { get; set; }
    public int LocationId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public decimal SubTotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
    public int Quantity { get; set; }
    public string CashierId { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public virtual Location Location { get; set; }

    public virtual Product Product { get; set; }
    public virtual User Cashier { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    //public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; }


}
