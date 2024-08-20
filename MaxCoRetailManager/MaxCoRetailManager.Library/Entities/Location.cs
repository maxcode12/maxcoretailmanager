using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Location : Base
{
    public int LocationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParentLocationId { get; set; }
    public Location ParentLocation { get; set; } = new Location();
    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = new User();
    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    //public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = new List<InventoryTransaction>();
    //public virtual ICollection<InventoryTransactionDetail> InventoryTransactionDetails { get; set; } = new List<InventoryTransactionDetail>();
    //public virtual ICollection<InventoryTransactionType> InventoryTransactionTypes { get; set; } = new List<InventoryTransactionType>();
    //public virtual ICollection<Return> Returns { get; set; } = new List<Return>();
    //public virtual ICollection<StockTransfer> StockTransfers { get; set; } = new List<StockTransfer>();
    //public virtual ICollection<StockTake> StockTakes { get; set; } = new List<StockTake>();
    //public virtual ICollection<StockAdjustment> StockAdjustments { get; set; } = new List<StockAdjustment>();
    //public virtual ICollection<StockCount> StockCounts { get; set; } = new List<StockCount>();
    //public virtual ICollection<StockCountDetail> StockCountDetails { get; set; } = new List<StockCountDetail>();
    //public virtual ICollection<StockTransferDetail> StockTransferDetails { get; set; } = new List<StockTransferDetail>();
    //public virtual ICollection<StockAdjustmentDetail> StockAdjustmentDetails { get; set; } = new List<StockAdjustmentDetail>();
    //public virtual ICollection<ReturnDetail> ReturnDetails { get; set; } = new List<ReturnDetail>();

}
