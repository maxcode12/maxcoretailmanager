using System.ComponentModel.DataAnnotations;

namespace MaxCoRetailManager.Application.DTOs.UserDTO;

public class UserCreateDto
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    [EmailAddress]
    public string UserName { get; set; } = string.Empty;
    public bool EmailConfirmed { get; set; }
}
