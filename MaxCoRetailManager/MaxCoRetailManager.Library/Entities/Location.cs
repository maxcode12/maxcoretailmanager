using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Location : Base
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? ParentLocationId { get; set; }
    public virtual Location? ParentLocation { get; set; }



    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    public virtual ICollection<Product> Products { get; set; }


}
