using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Customer : BaseString
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [StringLength(19)]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;


}
