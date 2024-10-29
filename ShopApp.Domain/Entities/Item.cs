using ShopApp.Domain.Common;

namespace ShopApp.Domain;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<ItemCategory> ItemCategories { get; set; }
    
}