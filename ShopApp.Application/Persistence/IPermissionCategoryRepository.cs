using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IPermissionCategoryRepository {

    Task<PermissionCategory?> Get(Guid id);
    Task<IReadOnlyCollection<PermissionCategory>> GetAll();

    Task<List<PermissionCategory>> GetAllWithPermissionActions();
    Task InsertAsync(PermissionCategory category);
    Task InsertRangeAsync(ICollection<PermissionCategory> categories);
    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(Guid[] ids);
    Task<bool> IsExists(Guid id);
    Task<bool> IsExists(string name);
    Task UpdateAsync(PermissionCategory category);
    Task SaveAsync();

}