using MaxCoRetailManager.Core.Common;
using Microsoft.AspNetCore.Identity;

namespace MaxCoRetailManager.Core.Entities;

public class RolePermission : BaseString
{
    public string? RoleId { get; set; }
    public string? PermissionId { get; set; }
    public bool Create { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }

    public Permission Permission { get; set; }
    public IdentityRole Role { get; set; }

}
