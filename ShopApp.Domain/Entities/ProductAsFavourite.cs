using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;

public class ProductAsFavourite : BaseEntity
{
    public Guid UserId { get; set; }
    
    public User User { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Product Product { get; set; }
    
}