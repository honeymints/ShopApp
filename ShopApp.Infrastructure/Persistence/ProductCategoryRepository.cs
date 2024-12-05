using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext context) : base(context) { }

    public async Task<IReadOnlyCollection<Category?>> GetCategoriesByProductIds(Guid[] productIds)
    {
        return await _context.ProductCategories
            .Where(x => productIds.Contains(x.ProductId))
            .Select(x => x.Category)
            .ToListAsync();
    }


    public async Task<IReadOnlyCollection<Product?>> GetProductsByCategoryIds(Guid[] categoryIds)
    {
         return await _context.ProductCategories
            .Where(x => categoryIds.Contains(x.CategoryId))
            .Select(x => x.Product)
            .ToListAsync();
    }
    public async Task<ProductCategory?> Get(Guid productId, Guid categoryId)
    {
       return await _context.ProductCategories
                                    .Where(x=>x.ProductId == productId
                                              && x.CategoryId == categoryId)
                                    .FirstOrDefaultAsync();

    }

}