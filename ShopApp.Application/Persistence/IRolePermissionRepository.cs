using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IRolePermissionRepository {

    Task<PermissionsClaim> GetPermissionClaimsByUserAsync(Guid userId);

    Task GetRolesAsync();

    Task AddPermissionsToRole(RolePermission rolePermission);

    Task DeletePermissionsFromRole(Guid RolePermissionId);


}