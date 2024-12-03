using ShopApp.Domain.Common;
using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;

public class PermissionAction : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public PermissionActionEnum Value { get; set; }
    public Guid PermissionCategoryId { get; set; }
    public virtual PermissionCategory? PermissionCategory { get; set; }

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = [];
}
