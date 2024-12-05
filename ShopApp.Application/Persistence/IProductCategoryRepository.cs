using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Persistence;


public interface IProductCategoryRepository
{
    Task<ProductCategory?> Get(Guid id);

    Task SaveAsync();
    Task InsertAsync(ProductCategory productCategory);
    
    Task InsertRangeAsync(ICollection<ProductCategory> productCategories);
    Task DeleteAsync(Guid id);

    Task<ProductCategory?> Get(Guid productId, Guid categoryId);

    Task DeleteRangeAsync(Guid[] ids);
    
    Task<bool> IsExists(Guid itemId);

    public Task<IReadOnlyCollection<Category?>> GetCategoriesByProductIds(Guid[] productIds);

    public Task<IReadOnlyCollection<Product?>> GetProductsByCategoryIds(Guid[] categoryIds);
}