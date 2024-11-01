using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Common.Services;
using ShopApp.Application.Common.Interfaces;
using ShopApp.Application.Persistence;
using ShopApp.Infrastructure.Authentication;
using ShopApp.Infrastructure.Persistence;
using ShopApp.Infrastructure.Services;

namespace ShopApp.Infrastructure;

public static class DependencyInjection {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
        services.AddDbContext<AppDbContext>(options => 
            options.UseNpgsql(configurationManager.GetConnectionString("DefaultConnection")));
        
        services.AddSingleton<ITokenGenerator, TokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        
        return services;
    }
}