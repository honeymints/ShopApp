using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;


public class PermissionCategory : BaseEntity
{
    public PermssionCategoryEnum Valur { get; set; }

    public PermissionAction PermissionAction { get; set; }

}
