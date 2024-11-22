namespace ShopApp.Application.DTOs.RolePermissions;



public class PermissionsToRoleDto
{
    public Guid RoleId { get; set; }

    public Guid[] PermissionActionIds { get; set; }
}