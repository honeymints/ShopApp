using Microsoft.EntityFrameworkCore;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Infrastructure.Persistence.Common;

namespace ShopApp.Infrastructure.Persistence;


public class LoginUserRepository : BaseRepository<LoginUser>, ILoginUserRepository 
{
    public LoginUserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> IsUserLoggedIn(string email)
    {
        return await _context.LoginUsers
        .AnyAsync(x=>x.Email==email);
    }
}