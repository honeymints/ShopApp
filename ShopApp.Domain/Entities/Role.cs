using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = [];

    public virtual ICollection<RolePermission> RolePermissions { get; set; } = [];
}