using ShopApp.Application.Persistence;
using ShopApp.Domain;
using ShopApp.Infrastructure.Persistence;

namespace ShopApp.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context =context;
    }
    public User? GetUserById(Guid userId)
    {
        return _context.Users.SingleOrDefault(u => u.Id == userId);
    }

    public User? GetUserByEmail(string email)
    {
        return _context.Users.SingleOrDefault(u => u.Email == email);
    }

    public IQueryable<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public void InsertUser(User user)
    {
        _context.Users.Add(user);
    }

    public void DeleteUser(Guid userId)
    {
        
    }
}