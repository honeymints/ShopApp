using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IRolePermissionRepository {

   Task<RolePermission?> FindById(Guid userId);
    Task<PermissionsClaim> GetPermissionClaimsByUserAsync(Guid userId);

    Task SaveAsync();
    Task InsertAsync(RolePermission rolePermission);
    
    Task InsertRangeAsync(ICollection<RolePermission> rolePermissions);
    Task DeleteAsync(Guid rolePermissionId);
    
    Task<bool> IsExists(Guid itemId);

    Task<bool> IsRoleExistsWithSuchPermission(Guid roleId, Guid permissionId);

    public Task<Guid?[]> FindPermissionsByRoleId(Guid roleId);
}