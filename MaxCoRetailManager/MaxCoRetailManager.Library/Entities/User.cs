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

    public string FullName => $"{FirstName} {LastName}";

    public string PhotoUrl { get; set; } = string.Empty;

    public bool IsApproved { get; set; }

    public string RefreshToken { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;

}


