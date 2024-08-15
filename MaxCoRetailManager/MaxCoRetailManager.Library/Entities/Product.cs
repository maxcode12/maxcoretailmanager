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
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public ICollection<Inventory> Inventories { get; set; }


}
