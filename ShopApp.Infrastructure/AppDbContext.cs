using Microsoft.EntityFrameworkCore;
using ShopApp.Domain;

namespace ShopApp.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){  }

    public DbSet<User> Users { get; set; }

}