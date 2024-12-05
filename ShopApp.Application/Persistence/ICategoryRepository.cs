using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface ICategoryRepository
{
    Task AddCategoryToProduct(Category category, Product product);

    Task DeleteCategoryFromProduct(Guid categoryId, Guid productId);

    Task UpdateProductCategory(Category category, Product product);
    Task<IReadOnlyCollection<Category>> GetAll();

    Task<Category?> Get(Guid id);

    Task DeleteRangeAsync(Guid[] ids);
    Task SaveAsync();
    Task InsertAsync(Category category);
    
    Task InsertRangeAsync(ICollection<Category> categories);
    Task DeleteAsync(Guid categoryId);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(Category category);
}