using ShopApp.Domain.Enums;

namespace ShopApp.Application.DTOs.RolePermissions;

public class PermissionActionDto
{
    public Guid Id { get; set; }

    public PermissionActionEnum Value { get; set; }


}