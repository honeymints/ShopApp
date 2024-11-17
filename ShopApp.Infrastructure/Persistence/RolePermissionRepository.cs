using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class RolePermissionRepository : IRolePermissionRepository
{
    private readonly AppDbContext _context;
    public RolePermissionRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task AddPermissionsToRole(Role role, PermissionAction[] permissionAction)
    {
        throw new NotImplementedException();
    }

    public Task DeletePermissionsFromRole(Guid RoleId, Guid PermissionActionId)
    {
        throw new NotImplementedException();
    }

    public async Task<PermissionsClaim> GetPermissionClaimsByUserAsync(Guid userId)
    {
        //check what way is better
    //    var a = _context.UserRoles
    //     .Where(x=>x.UserId==loginUser.UserId)
    //     .Include(x=>x.Role.RolePermissions)
    //     .SelectMany(x=>x.Role.RolePermissions);

        // return await _context.RolePermissions
        // .Include(x=>x.Role.UserRoles)
        // .Where(x=>x.Role.UserRoles.Any(x=>x.UserId==user.Id))
        // .AsNoTracking()
        // .Select(x=> x.PermissionAction)
        // .Select(x=>new PermissionsActionClaim {
        //     Name = x.Name,
        //     Value = x.Value,
        // }).ToListAsync();

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
                .Select(rp => new PermissionActionClaim
                {
                    Name = rp.PermissionAction.Name,
                    Value = rp.PermissionAction.Value
                })
                .ToList()
        })
        .ToList();

    return new PermissionsClaim()
    {
        Applications = permissionCategories
    };
}
    }

    public Task GetRolePermissionsAsync()
    {
        throw new NotImplementedException();
    }

    public Task GetRolesAsync()
    {
        throw new NotImplementedException();
    }
}