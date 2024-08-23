using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Sale : Base
{
    public int? ProductId { get; set; }

    public decimal? SubTotal { get; set; }
    public decimal? Tax { get; set; }
    public decimal? Total { get; set; }
    public int? Quantity { get; set; }
    public decimal? PurchasePrice { get; set; }
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public virtual Product? Product { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();


}
