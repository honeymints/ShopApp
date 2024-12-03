namespace ShopApp.Contracts.PermissionAction;


public record CreatePermissionActionRequest(
    string Name,
    string Description,
    int Value,
    Guid CategoryId
);