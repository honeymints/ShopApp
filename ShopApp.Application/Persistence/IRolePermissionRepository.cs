using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IRolePermissionRepository {

    Task<IReadOnlyCollection<PremissionActionClaim>> GetPermissionClaimsByUserAsync(LoginUser loginUser);

    Task GetRolesAsync();

    Task GetRolePermissionsAsync();

}