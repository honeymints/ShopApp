using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;

namespace ShopApp.Application.Services.Products;

public interface IProductService
{
    Task<List<ProductDto>> GetProducts();

    Task<ProductDto?> GetProductById(Guid id);
    
    Task AddProduct(ProductDto product);

    Task AddCategoryToProduct(CategoryDto categoryDto);
}
