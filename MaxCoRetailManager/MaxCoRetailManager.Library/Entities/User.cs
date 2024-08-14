using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(128)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]

    public string PasswordHash { get; set; } = string.Empty;

}
