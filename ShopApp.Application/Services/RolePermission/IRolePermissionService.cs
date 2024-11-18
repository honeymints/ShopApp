using ShopApp.Application.DTOs.RolePermissions;

namespace ShopApp.Application.Services;


public interface IRolePermissionService
{

    Task AssignPermissionsToRole(PermissionsToRoleDto assignPermissionsToRoleDto);

    Task UnAssignPermissionsFromRole(PermissionsToRoleDto assignPermissionsToRoleDto);
    
}