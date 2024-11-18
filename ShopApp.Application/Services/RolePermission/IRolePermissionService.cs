using ShopApp.Application.DTOs;

namespace ShopApp.Application.Services;


public interface IRolePermissionService
{

    Task AssignPermissionsToRole(PermissionsToRoleDto assignPermissionsToRoleDto);

    Task UnAssignPermissionsFromRole(PermissionsToRoleDto assignPermissionsToRoleDto);

    Task<RoleDto> GetRoles();
    
}