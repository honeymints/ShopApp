using ShopApp.Domain;

namespace ShopApp.Application.Persistence;

public interface IUserRepository
{
    User? GetUserById(Guid userId);

    User? GetUserByEmail(string email);
    
    IQueryable<User> GetUsers();

    void Save();

    void Insert(User user);

    void Delete(Guid userId);
}