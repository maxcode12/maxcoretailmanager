using MaxCoRetailManager.Core.Common;
using MaxCoRetailManager.Core.Enums;
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
    public Category Category { get; set; }
}
