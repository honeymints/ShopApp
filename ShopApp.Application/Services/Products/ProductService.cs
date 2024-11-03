using MapsterMapper;
using ShopApp.Application.Persistence;
using ShopApp.Application.Persistence.DTOs;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await _productRepository.GetAll();
        var productDto = products.Select(s => _mapper.Map<ProductDto>(s));
        return productDto;
    }

    public async Task<ProductDto?> GetProductById(Guid id)
    {
        if (await _productRepository.IsExists(id))
        {
            var product = await _productRepository.FindById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;
        }
        throw new KeyNotFoundException();
    }

    public async Task AddProduct(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.InsertAsync(product);
        await _productRepository.SaveAsync();
    }
}