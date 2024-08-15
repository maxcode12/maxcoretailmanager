using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Sale : Base
{
    public int ProductId { get; set; }
    public decimal SubTotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
    public int Quantity { get; set; }
    public string CashierId { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;

    public Product Product { get; set; }
    public User Cashier { get; set; }
    public ICollection<SaleDetail> SaleDetails { get; set; }


}
