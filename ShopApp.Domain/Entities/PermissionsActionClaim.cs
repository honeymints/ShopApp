using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;

public class PermissionsActionClaim
{
    public string Name { get; set; }

    public PermissionActionEnum Value { get; set; }
}