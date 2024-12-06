using Mapster;
using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    
    public async Task UpdateProductCategory(Category category, Product product)
    {
        var productCategory = await _context.ProductCategories
        .Where(pc => pc.Category.Equals(category) && pc.Product.Equals(product))
        .FirstOrDefaultAsync();

        _context.ProductCategories.Update(productCategory);
    }

    public async Task<bool> IsExists(string name)
    {
        return await _context.Categories
                             .AnyAsync(x => x.Name.ToLower().Equals(name.ToLower()));
    }

}
