using ShopApp.Application.DTOs.PermissionAction;

namespace ShopApp.Application.DTOs.Role;


public class RoleDto
{
    public Guid Id { get; set; }

    public string? Description { get; set; }

    public string Name { get; set; }

    public ICollection<PermissionActionDto> PermissionActions { get; set; }
}
