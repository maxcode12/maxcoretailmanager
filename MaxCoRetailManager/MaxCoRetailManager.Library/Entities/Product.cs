using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Product : Base
{
    [Required]
    [StringLength(256)]
    public string Name { get; set; } = string.Empty;

    [StringLength(512)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [StringLength(256)]
    public string Sku { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [StringLength(10)]
    public string DeliveryTimeSpan { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = string.Empty;

    public bool IsAvailable { get; set; }

    public bool IsOnSale { get; set; }
    public bool IsSellOnPOS { get; set; }

    public bool IsSellOnline { get; set; }

    public int CategoryId { get; set; }
    public int LocationId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; }


}
