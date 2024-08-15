using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Category : Base
{
    public int CategoryId { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;
    public int ParentId { get; set; }
    public string? Description { get; set; } = string.Empty;

}
