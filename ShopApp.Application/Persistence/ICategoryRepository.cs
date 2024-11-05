using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface ICategoryRepository
{
    Task AddCategoryToProduct(Category category, Product product);

    Task DeleteCategoryFromProduct(Guid categoryId, Guid productId);

    Task UpdateProductCategory(Category category, Product product);
    Task<IEnumerable<Category>> GetAll();
    Task SaveAsync();
    Task InsertAsync(Category category);
    
    Task InsertRangeAsync(IEnumerable<Category> categories);
    Task DeleteAsync(Guid categoryId);
    
    Task<bool> IsExists(Guid itemId);
    Task UpdateAsync(Category category);
}