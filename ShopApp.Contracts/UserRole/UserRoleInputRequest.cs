namespace ShopApp.Contracts.UserRole;


public record UserRoleInputRequest(
    Guid userId,
    Guid[] roleIds
);