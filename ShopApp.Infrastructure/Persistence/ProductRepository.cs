using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Product>> GetItemsByCategories(Guid categoryId)
    {
        var items = await _context.Products
            .Include(i => i.ProductCategories)
            .Where(i => i.ProductCategories.Any(ic => ic.CategoryId == categoryId))
            .ToListAsync();
        return items;
    }

    public async Task<IEnumerable<Product>> GetLikedItemsOfUser(Guid userId)
    {
        var items = await _context.Products
            .Include(c => c.ProductCategories)
            .Where(c => c.ProductAsFavourites.Any(u => u.UserId == userId))
            .ToListAsync();
        return items;
    }
}