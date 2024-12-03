using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class PermissionCategoryRepository : BaseRepository<PermissionCategory>, IPermissionCategoryRepository
{
    public PermissionCategoryRepository(AppDbContext context) : base(context)
    {
    }
}