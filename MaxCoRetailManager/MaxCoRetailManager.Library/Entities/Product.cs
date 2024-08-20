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

    public decimal Price { get; set; }
    public string DeliveryTimeSpan { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public bool IsAvailable { get; set; }
    public bool IsOnSale { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = new();
    public string UserId { get; set; } = string.Empty;

    public User User { get; set; } = new();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();


}
