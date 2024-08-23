using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Product : Base
{
    [Required]

    public string Name { get; set; } = string.Empty;


    public string? Description { get; set; } = string.Empty;

    [Required]

    public string Sku { get; set; } = string.Empty;

    [Required]
    public decimal? Price { get; set; }


    public string DeliveryTimeSpan { get; set; } = string.Empty;

    public string? ImageUrl { get; set; } = string.Empty;

    public bool? IsAvailable { get; set; }

    public bool? IsOnSale { get; set; }
    public bool? IsSellOnPOS { get; set; }

    public bool? IsSellOnline { get; set; }

    public int? CategoryId { get; set; }
    public int? LocationId { get; set; }
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public virtual Category? Category { get; set; }



    public virtual Location? Location { get; set; }
    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


}
