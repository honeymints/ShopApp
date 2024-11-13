using ShopApp.Domain.Common;

namespace ShopApp.Domain.Entities;


public class LoginUser : BaseEntity
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}