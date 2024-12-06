using System.ComponentModel.DataAnnotations;

namespace ShopApp.Contracts.PermissionCategory;


public record PermissionCategoryRequest(
    [Required]
    string Name,
    string? Description,
    [Required]
    int Value
);