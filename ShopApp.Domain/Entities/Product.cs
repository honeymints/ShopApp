using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Rating? Rating { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    public virtual ICollection<ProductAsFavourite> ProductAsFavourites { get; set; } = new List<ProductAsFavourite>();
}