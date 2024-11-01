using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IProductRepository
{
    Task<Product?> FindById(Guid itemId);

    Task<IEnumerable<Product>> GetItemsByCategories(Guid categoryIdId);
    
    Task<IEnumerable<Product>> GetLikedItemsOfUser(Guid userId);
    
    Task<IEnumerable<Product>> GetAll();

    Task SaveAsync();

    Task InsertAsync(Product product);
    
    Task InsertRangeAsync(IEnumerable<Product> product);

    Task DeleteAsync(Guid itemId);
    
    Task UpdateAsync(Product product);
    
    Task<bool> IsExists(Guid itemId);
}