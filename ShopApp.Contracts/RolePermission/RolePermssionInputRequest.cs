namespace ShopApp.Contracts.RolePermission;



public record RolePermissionInputRequest (
    Guid roleId,
    Guid[] permissionActionIds
);