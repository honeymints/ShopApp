using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class PermissionCategoryRepository : BaseRepository<PermissionCategory>, IPermissionCategoryRepository
{
    public PermissionCategoryRepository(AppDbContext context) : base(context) { }

    public async Task<List<PermissionCategory>> GetAllWithPermissionActions()
    {
        return await _context.PermissionCategories.Include(x => x.PermissionActions)
                                                  .AsNoTracking()
                                                  .ToListAsync();
    }

    public override async Task<PermissionCategory?> Get(Guid id)
    {
        return await _context.PermissionCategories.Include(x => x.PermissionActions)
                                                  .FirstOrDefaultAsync(x=>x.Id.Equals(id));
    }

    public async Task<bool> IsExists(string name) => await _context.PermissionCategories.AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()));

}