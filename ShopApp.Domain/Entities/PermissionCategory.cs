using ShopApp.Domain.Common;
using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;


public class PermissionCategory : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public PermissionCategoryEnum Value { get; set; }
    public virtual ICollection<PermissionAction> PermissionActions { get; set; } = [];

}
