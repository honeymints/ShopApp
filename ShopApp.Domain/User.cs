using ShopApp.Domain.Common;

namespace ShopApp.Domain;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}