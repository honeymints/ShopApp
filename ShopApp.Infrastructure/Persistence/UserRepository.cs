using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
    
    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email == email);
    }
    
    
}