using ShopApp.Application.DTOs.PermissionAction;
using ShopApp.Domain.Enums;

namespace ShopApp.Application.DTOs.PermissionCategory;


public class PermissionCategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public PermissionActionEnum Value { get; set; }
    public virtual ICollection<PermissionActionDto> PermissionActions { get; set; } = [];
}