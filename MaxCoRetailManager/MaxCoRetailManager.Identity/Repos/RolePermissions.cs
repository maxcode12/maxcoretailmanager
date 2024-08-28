//using MaxCoRetailManager.Application.Contracts.Identity;
//using MaxCoRetailManager.Core.Entities;
//using MaxCoRetailManager.Identity.IdentityContext;
//using Microsoft.EntityFrameworkCore;

//namespace MaxCoRetailManager.Identity.Repos;

//public class RolePermissions : IRolePermissions
//{
//    private readonly IAuthRepository _authRepository;
//    //private readonly RoleManager<IdentityRole> _roleManager;
//    private readonly MaxCoRetailIdentityDbContext _context;
//    public RolePermissions(
//        IAuthRepository authRepository,
//        MaxCoRetailIdentityDbContext context
//        /*RoleManager<IdentityRole> roleManager*/)
//    {
//        _authRepository = authRepository;
//        _context = context;

//    }

//    public async Task<RolePermission> AssignRolesAsync(string role, string permission)
//    {

//        var rolePermission = new RolePermission
//        {
//            RoleId = role,
//            PermissionId = permission
//        };
//        await _context.SaveChangesAsync();


//        return rolePermission;

//    }

//    public async Task<Permission> CreatePermission(Permission permission)
//    {

//        var newPermission = new Permission
//        {
//            Id = permission.Id,
//            Name = permission.Name
//        };
//        await _context.SaveChangesAsync();
//        return newPermission;
//    }


//    public async Task<IReadOnlyList<RolePermission>> GetRolePermissionsAsync(string roleId)
//    {
//        return await _context.RolePermissions.Where(x => x.RoleId == roleId).ToListAsync();
//    }




//}
