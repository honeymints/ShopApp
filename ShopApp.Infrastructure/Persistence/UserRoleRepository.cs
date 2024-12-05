using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(AppDbContext context) : base(context) { }

    public async Task<Guid[]> GetRolesByUserId(Guid userId)
    {
        var roleIds = await _context.UserRoles
        .Where(x => x.UserId.Equals(userId))
        .Select(x => x.RoleId)
        .ToArrayAsync();
        return roleIds;
    }

    public async Task<bool> IsUserExistsWithSuchRoles(Guid userId, Guid roleId)
    {
        return await _context.UserRoles
        .AnyAsync(x => x.UserId.Equals(userId) &&
                x.RoleId.Equals(roleId));
    }
}