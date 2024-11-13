using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;


public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;
}