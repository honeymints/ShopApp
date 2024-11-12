using System.Reflection.Metadata.Ecma335;
using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class PermissionAction : BaseEntity
{
    public string Name { get; set; }

    public PermissionActionEnum Value { get; set; }
}
