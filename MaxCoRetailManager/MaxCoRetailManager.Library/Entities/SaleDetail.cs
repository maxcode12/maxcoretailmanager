using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class SaleDetail : Base
{


    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public int InventoryId { get; set; }
    public int LocationId { get; set; }
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal Tax { get; set; }
    public DateTime SaleDate { get; set; }

    //navigation properties
    public virtual Sale Sale { get; set; }
    public virtual Product Product { get; set; }
    public virtual Location Location { get; set; }
    //public virtual ICollection<Payment> Payments { get; set; }


}
