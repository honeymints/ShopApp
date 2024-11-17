namespace ShopApp.Application.DTOs;



public class PermissionToRoleAssignDto
{

    public Guid RoleId { get; set; }

    public Guid[] PermissionActionIds { get; set; }
}