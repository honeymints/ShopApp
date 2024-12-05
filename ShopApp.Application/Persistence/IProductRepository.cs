using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;

public interface IProductRepository
{
    Task<Product?> Get(Guid itemId);

    Task<IEnumerable<Product>> GetItemsByCategories(Guid categoryIdId);
    
    Task<IEnumerable<Product>> GetLikedItemsOfUser(Guid userId);
    
    Task<IReadOnlyCollection<Product>> GetAll();

    Task SaveAsync();

    Task InsertAsync(Product product);
    
    Task InsertRangeAsync(ICollection<Product> product);

    Task DeleteAsync(Guid itemId);

    Task DeleteRangeAsync(Guid[] ids);
    
    Task UpdateAsync(Product product);
    
    Task<bool> IsExists(Guid itemId);
}