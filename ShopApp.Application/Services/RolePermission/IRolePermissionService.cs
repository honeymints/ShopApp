using ShopApp.Application.DTOs.RolePermissions;

namespace ShopApp.Application.Services;


public interface IRolePermissionService
{
    Task AssignPermissionsToRole(Guid RoleId, Guid[] PermissionActionIds);

    Task UnAssignPermissionsFromRole(Guid RoleId, Guid[] PermissionActionIds);
}