using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();

    Task<Product?> GetProductById(Guid id);
    
    Task AddProduct(Product product);
}