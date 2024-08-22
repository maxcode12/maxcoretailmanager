using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Category : Base
{

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Description { get; set; } = string.Empty;

    public string UserId { get; set; } = Guid.Empty.ToString();

    User User { get; set; }

    //nullable parent category id to allow for a category to have no parent category
    //Assuming a one to many relationship between parent and child categories

    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }


    //navigation properties assume that a category can have many users
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<SaleDetail> SaleDetails { get; set; }


}
