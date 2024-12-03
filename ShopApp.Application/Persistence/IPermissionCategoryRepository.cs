using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IPermissionCategoryRepository {

    Task<PermissionCategory?> FindById(Guid id);

    Task<IReadOnlyCollection<PermissionCategory>> GetAll();
    Task SaveAsync();
    Task InsertAsync(PermissionCategory category);
    
    Task InsertRangeAsync(ICollection<PermissionCategory> categories);
    Task DeleteAsync(Guid id);
    
    Task<bool> IsExists(Guid id);
    Task UpdateAsync(PermissionCategory category);

}