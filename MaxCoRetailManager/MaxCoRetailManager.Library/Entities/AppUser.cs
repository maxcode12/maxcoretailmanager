using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class AppUser
{
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [StringLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(100)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [StringLength(256)]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public DateTime LastLoginDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }

}
