using ShopApp.Domain.Common;

namespace ShopApp.Domain;

public class ItemCategory : BaseEntity
{
    public int ItemId { get; set; }

    public virtual Item Item { get; set; } = null!;
    
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

}