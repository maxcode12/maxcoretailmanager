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


}
