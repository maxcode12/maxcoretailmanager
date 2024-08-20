using MaxCoRetailManager.Application.DTOs.Common;

namespace MaxCoRetailManager.Application.DTOs.UserDTO;

public class UserRoleDto : BaseStringDto
{
    public string RoleName { get; set; } = string.Empty;
    public string NormalizedName { get; set; } = string.Empty;
}
