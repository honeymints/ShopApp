using Microsoft.EntityFrameworkCore;
using ShopApp.Domain.Entities;

namespace ShopApp.Infrastructure.Persistence.Common;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Role> Roles { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<PermissionAction> PermissionActions { get; set; }

    public DbSet<PermissionCategory> PermissionCategories { get; set; }

    public DbSet<RolePermission> RolePermissions { get; set; }

    public DbSet<LoginUser> LoginUsers { get; set; }

}