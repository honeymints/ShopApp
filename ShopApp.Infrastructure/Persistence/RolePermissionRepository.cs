using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class RolePermissionRepository : BaseRepository<RolePermission>, IRolePermissionRepository
{
    public RolePermissionRepository(AppDbContext context) : base(context)
    {

    }

    public async Task<PermissionsClaim> GetPermissionClaimsByUserAsync(Guid userId)
    {
        // Fetch the role for the user
        var roleId = await _context
            .UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .FirstOrDefaultAsync();

        if (roleId == default)
        {
            // Handle case where the user does not have an assigned role
            return new PermissionsClaim();
        }

        // Fetch the permissions for the user's role
        var rolePermissions = await _context
            .RolePermissions
            .Where(rp => rp.RoleId == roleId)
            .Include(rp => rp.PermissionAction)
            .ThenInclude(pa => pa.PermissionCategory)
            .ToListAsync();

        var permissionCategories = rolePermissions
            .GroupBy(rp => rp.PermissionAction?.PermissionCategory)
            .Select(categoryGroup => new PermissionCategoryClaim
            {
                Name = categoryGroup.Key?.Name,
                Value = categoryGroup.Key.Value,
                Actions = categoryGroup
                    .Select(rp => new PermissionsActionClaim
                    {
                        Name = rp.PermissionAction.Name,
                        Value = rp.PermissionAction.Value
                    })
                    .ToList()
            })
            .ToList();

        return new PermissionsClaim()
        {
            Categories = permissionCategories
        };
    }

    public Task GetRolePermissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetRolesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsRoleExistsWithSuchPermission(Guid roleId, Guid permissionId)
    {
        return await _context.RolePermissions
        .AnyAsync(x => x.PermissionActionId == permissionId
        && x.RoleId == roleId);
    }

    public async Task<Guid?[]> FindPermissionsByRoleId(Guid roleId)
    {
        return await _context.RolePermissions
        .Where(x => x.RoleId == roleId)
        .Select(x => x.PermissionActionId)
        .ToArrayAsync();
    }
}