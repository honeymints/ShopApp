using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class ProductAddedToCart : BaseEntity
{
    public Guid ProductId { get; set; }
    
    public virtual Product Product { get; set; }
    
    public Guid CartId { get; set; }
    
    public virtual Cart Cart { get; set; }
    
    public int Quantity { get; set; }
}