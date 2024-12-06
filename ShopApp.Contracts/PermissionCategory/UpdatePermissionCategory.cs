namespace ShopApp.Contracts.PermissionCategory;


public record UpdatePermissionCategory(
    Guid Id,
    string Name,
    string? Description,
    int Value
);