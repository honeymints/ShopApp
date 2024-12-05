using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;



public interface IPermissionActionRepository
{

    Task<IReadOnlyCollection<PermissionAction>> GetAll();

    Task<PermissionAction?> Get(Guid id);
    Task SaveAsync();
    Task InsertAsync(PermissionAction permissionAction);
    
    Task InsertRangeAsync(ICollection<PermissionAction> permissionAction);
    Task DeleteAsync(Guid permissionActionId);
    Task DeleteRangeAsync(Guid[] ids);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(PermissionAction permissionAction);

}