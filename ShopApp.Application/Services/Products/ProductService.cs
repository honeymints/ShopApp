using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> GetProducts()
    {
       return await _productRepository.GetAll();
    }

    public async Task<Product?> GetProductById(Guid id)
    {
        if (await _productRepository.IsExists(id))
        {
            return await _productRepository.FindById(id);
        }
        throw new KeyNotFoundException();
    }
    
    public async Task AddProduct(Product product)
    {
        _productRepository.InsertAsync(product);
        _productRepository.SaveAsync();
    }
}