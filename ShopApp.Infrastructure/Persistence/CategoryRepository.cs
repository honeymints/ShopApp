using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task AddCategoryToProduct(Category category, Product product)
    {
        await _context.ProductCategories.AddAsync(new ProductCategory{
            Category = category,
            Product = product,
        });
    }

    public async Task DeleteCategoryFromProduct(Guid categoryId, Guid productId)
    {
        var productCategory = _context.ProductCategories
        .Where(pc=> pc.CategoryId == categoryId && pc.ProductId == productId);

        await _context.Remove(productCategory);
    }

    public Task UpdateProductCategory(Category category, Product product)
    {
        
    }
}
