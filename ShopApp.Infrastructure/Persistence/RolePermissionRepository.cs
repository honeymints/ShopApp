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
    public async Task<IReadOnlyCollection<PremissionActionClaim>> GetPermissionClaimsByUserAsync(LoginUser loginUser)
    {
        //check what way is better
    //    var a = _context.UserRoles
    //     .Where(x=>x.UserId==loginUser.UserId)
    //     .Include(x=>x.Role.RolePermissions)
    //     .SelectMany(x=>x.Role.RolePermissions);

        return await _context.RolePermissions
        .Include(x=>x.Role.UserRoles)
        .Where(x=>x.Role.UserRoles.Any(x=>x.UserId==loginUser.UserId))
        .AsNoTracking()
        .Select(x=> x.PermissionAction)
        .Select(x=>new PremissionActionClaim {
            Name = x.Name,
            Value = x.Value,
        }).ToListAsync();
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