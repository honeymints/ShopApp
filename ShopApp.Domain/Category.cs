using ShopApp.Domain.Common;

namespace ShopApp.Domain;

public class Category : BaseEntity
{
    public string Name { get; set; }
    
    public virtual ICollection<ItemCategory> ItemCategories { get; set; }
}