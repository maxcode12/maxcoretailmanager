using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Category : Base
{
    public int CategoryId { get; set; }
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Description { get; set; } = string.Empty;

    public int ParentCategoryId { get; set; }

    public string UserId { get; set; } = string.Empty;

    //navigation properties assume that a category can have many users
    public virtual ICollection<User> User { get; set; } = new List<User>();



}
