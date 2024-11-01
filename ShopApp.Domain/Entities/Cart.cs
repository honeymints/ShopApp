using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;
public class Cart : BaseEntity
{
    public int UserId { get; set; }
    
    public virtual User User { get; set; }
}