using MaxCoRetailManager.Core.Common;

namespace MaxCoRetailManager.Core.Entities;

public class Category : Base
{


    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string UserId { get; set; } = Guid.NewGuid().ToString();

    //nullable parent category id to allow for a category to have no parent category
    //Assuming a one to many relationship between parent and child categories

    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }


    //navigation properties assume that a category can have many users
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();


    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

}
