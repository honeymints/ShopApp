using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;

public class PremissionActionClaim
{
    public string Name { get; set; }

    public PermissionActionEnum Value { get; set; }
}