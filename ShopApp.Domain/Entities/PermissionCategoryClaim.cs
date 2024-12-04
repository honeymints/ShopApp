using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;


public class PermissionCategoryClaim
{
    public string Name { get; set; }

    public PermissionCategoryEnum Value { get; set; }

    public ICollection<PermissionsActionClaim> Actions { get; set; } = [];
}