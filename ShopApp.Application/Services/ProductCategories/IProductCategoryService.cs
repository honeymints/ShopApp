using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;

namespace ShopApp.Application.Services.ProductCategories;


public interface IProductCategoryService
{
    Task AssignCategoriesToProduct(Guid productId, Guid[] categoryIds);

    Task UnAssignCategoriesToProduct(Guid productId, Guid[] categoryIds);

    Task<IReadOnlyCollection<CategoryDto>> GetCategoriesFromProductIds(Guid[] productIds);

    Task<IReadOnlyCollection<ProductDto>> GetProductsFromCategoryIds(Guid[] categoryIds);
}