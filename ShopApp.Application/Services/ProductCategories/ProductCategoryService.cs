
using MapsterMapper;
using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Product;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.ProductCategories;


public class ProductCategoryService : IProductCategoryService
{
    private readonly IProductCategoryRepository _productCategoryReposity;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;

    public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
    ICategoryRepository categoryRepository, IProductRepository productRepository, IMapper mapper)
    {
        _productCategoryReposity = productCategoryRepository;
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task AssignCategoriesToProduct(Guid productId, Guid[] categoryIds)
    {
        foreach (var categoryId in categoryIds)
        {
            var productCategory = await _productCategoryReposity.Get(productId, categoryId);

            if (productCategory is not null)
                throw new Exception("there is already exact category in this product");
        }

        var productCategories = categoryIds.Select(x => new ProductCategory
        {
            ProductId = productId,
            CategoryId = x,
        }).ToList();

        await _productCategoryReposity.InsertRangeAsync(productCategories);
        await _productCategoryReposity.SaveAsync();
    }

    public async Task UnAssignCategoriesToProduct(Guid productId, Guid[] categoryIds)
    {
        var productCategoryIds = new List<Guid>() { };
        foreach (var categoryId in categoryIds)
        {
            var productCategory = await _productCategoryReposity.Get(productId, categoryId);

            if (productCategory is null)
                throw new KeyNotFoundException("there is no such category in this product");

            productCategoryIds.Add(productCategory.Id);
        }

        await _productCategoryReposity.DeleteRangeAsync(productCategoryIds.ToArray());
    }
    public async Task<IReadOnlyCollection<CategoryDto>> GetCategoriesFromProductIds(Guid[] productIds)
    {

        var categories = await _productCategoryReposity.GetCategoriesByProductIds(productIds);

        var categoryDtos = categories
        .AsEnumerable()
        .Select(x => _mapper.Map<CategoryDto>(x))
        .ToList();

        return categoryDtos;
    }

    public async Task<IReadOnlyCollection<ProductDto>> GetProductsFromCategoryIds(Guid[] categoryIds)
    {
        var products = await _productCategoryReposity.GetProductsByCategoryIds(categoryIds);

        var productDtos = products
        .AsEnumerable()
        .Select(x=> _mapper.Map<ProductDto>(x))
        .ToList();

        return productDtos;
    }

}