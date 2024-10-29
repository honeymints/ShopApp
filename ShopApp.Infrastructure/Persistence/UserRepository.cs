using ShopApp.Application.Persistence;
using ShopApp.Domain;

namespace ShopApp.Infrastructure;

public class UserRepository : IUserRepository
{
    
    private static readonly List<User> users = new();
    public User? GetUserById(Guid userId)
    {
        return users.SingleOrDefault(u => u.Id == userId);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(u => u.Email == email);
    }

    public IQueryable<User> GetUsers()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

    public void InsertUser(User user)
    {
        users.Add(user);
    }

    public void DeleteUser(Guid userId)
    {
        
    }
}