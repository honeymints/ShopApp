using MapsterMapper;
using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    // private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetProducts()
    {
        var products = await _productRepository.GetAll();
        var productDto = products
        .Select(s => _mapper.Map<ProductDto>(s))
        .ToList();
        return productDto;
    }

    public async Task<ProductDto?> GetProductById(Guid id)
    {
        if (await _productRepository.IsExists(id))
        {
            var product = await _productRepository.Get(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        throw new KeyNotFoundException();
    }

    public async Task AddProduct(
        string name,
        string description,
        decimal price)
    {

        var product = new Product
        {
            Name = name,
            Price = price,
            Description = description
        };

        await _productRepository.InsertAsync(product);
        await _productRepository.SaveAsync();
    }

    public async Task AssignCategoryToProduct(CategoryDto categoryDto)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteProduct(Guid id)
    {
        await CheckIfExists(id);

        await _productRepository.DeleteAsync(id);
        await _productRepository.SaveAsync();
    }

    public async Task UpdateProduct(Guid id, string name, string description, decimal price, int[]? productCategoryIds)
    {
        await CheckIfExists(id);

        var product = await _productRepository.Get(id);

        product.Name = name;
        product.Description = description;
        product.Price = price;
        
    }

    public async Task CheckIfExists(Guid id)
    {
        if (!await _productRepository.IsExists(id))
        {
            throw new KeyNotFoundException("such product doesn't exist!");
        }
    }

}