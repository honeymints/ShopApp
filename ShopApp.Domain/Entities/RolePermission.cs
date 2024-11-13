using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class RolePermission : BaseEntity
{
    public Guid? RoleId { get; set; }

    public Role Role { get; set; } = null!;

    public Guid? PermissionActionId { get; set; } 

    public PermissionAction? PermissionAction { get; set; }

}