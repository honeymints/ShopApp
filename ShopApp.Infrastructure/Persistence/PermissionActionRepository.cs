using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class PermissionActionRepository : BaseRepository<PermissionAction>, IPermissionActionRepository
{
    public PermissionActionRepository(AppDbContext context) : base(context) { }
}