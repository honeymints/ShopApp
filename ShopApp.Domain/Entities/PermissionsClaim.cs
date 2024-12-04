using ShopApp.Domain.Enums;

namespace ShopApp.Domain.Entities;


public class PermissionsClaim
{

    // public Guid PermissionActionId { get; set; }

    // public PermissionAction PermissionAction { get; set; }
    public string Name { get; set; }

    public ICollection<PermissionCategoryClaim> Categories { get; set; } = new List<PermissionCategoryClaim>();
}