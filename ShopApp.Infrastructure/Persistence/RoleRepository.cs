using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class RoleRepository : BaseRepository<Role>, IRoleRepository
{
    public RoleRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsExists(string Name)
    {
        return await _context.Roles
        .AnyAsync(x=>x.Name.Equals(Name));
    }

}