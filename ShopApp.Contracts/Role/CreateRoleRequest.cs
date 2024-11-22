namespace ShopApp.Contracts.Role;


public record CreateRoleRequest(
    string Name,
    string? Description
);