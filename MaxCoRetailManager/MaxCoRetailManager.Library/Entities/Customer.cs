using MaxCoRetailManager.Core.Common;
using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class Customer : BaseString
{
    [Required]

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

}
