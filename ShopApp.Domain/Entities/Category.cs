using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}