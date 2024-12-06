using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface ICategoryRepository
{
    Task<IReadOnlyCollection<Category>> GetAll();

    Task<Category?> Get(Guid id);

    Task DeleteRangeAsync(Guid[] ids);
    Task SaveAsync();
    Task InsertAsync(Category category);
    
    Task InsertRangeAsync(ICollection<Category> categories);
    Task DeleteAsync(Guid categoryId);
    
    Task<bool> IsExists(Guid itemId);

    Task<bool> IsExists(string name);

    Task UpdateAsync(Category category);
}