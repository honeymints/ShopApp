using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Common.Services;
using ShopApp.Application.Interfaces;
using ShopApp.Infrastructure.Authentication;
using ShopApp.Infrastructure.Services;

namespace ShopApp.Infrastructure;

public static class DependencyInjection {

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.Configure<JwtSettings>(configurationManager.GetSection(JwtSettings.SectionName));
        services.AddSingleton<ITokenGenerator, TokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }
}