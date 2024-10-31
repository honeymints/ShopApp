using ShopApp.Application.Persistence;
using ShopApp.Domain;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure.Persistence;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }

    public User? GetUserById(Guid userId)
    {
        throw new NotImplementedException();
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email == email);
    }

    public IQueryable<User> GetUsers()
    {
        return _context.Users;
    }
    
    
}