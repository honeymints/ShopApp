using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;

namespace ShopApp.Application.Services.Products;

public interface IProductService
{
    Task<List<ProductDto>> GetProducts();

    Task<ProductDto?> GetProductById(Guid id);

    Task AddProduct(
        string name,
        string description,
        decimal price);

    Task AssignCategoryToProduct(CategoryDto categoryDto);

    Task DeleteProduct(Guid id);

    Task UpdateProduct(  
        Guid id, 
        string name,
        string description,
        decimal price,
        int[]? productCategoryIds);

    Task CheckIfExists(Guid id);
}
