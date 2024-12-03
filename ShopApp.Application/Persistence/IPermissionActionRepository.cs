using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;



public interface IPermissionActionRepository
{

    Task<IReadOnlyCollection<PermissionAction>> GetAll();

    Task<PermissionAction?> FindById(Guid id);
    Task SaveAsync();
    Task InsertAsync(PermissionAction permissionAction);
    
    Task InsertRangeAsync(ICollection<PermissionAction> permissionAction);
    Task DeleteAsync(Guid permissionActionId);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(PermissionAction permissionAction);

}