using ShopApp.Application.Persistence.DTOs;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetProducts();

    Task<ProductDto?> GetProductById(Guid id);
    
    Task AddProduct(ProductDto product);
}