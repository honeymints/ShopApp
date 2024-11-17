using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;


public class PermissionCategoryClaim
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public PermissionCategoryEnum Value { get; set; }

    public ICollection<PermissionsActionClaim> Actions { get; set; } = [];
}