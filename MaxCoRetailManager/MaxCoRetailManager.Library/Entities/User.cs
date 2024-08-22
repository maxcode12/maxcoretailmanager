using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class User : IdentityUser
{


    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;


    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<Location> Locations { get; set; }
}


