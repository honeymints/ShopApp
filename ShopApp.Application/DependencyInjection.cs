using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Services;
using ShopApp.Application.Services.Authentication;
using ShopApp.Application.Services.Products;

namespace ShopApp.Application;

public static class DependencyInjection {

    public static IServiceCollection AddApplication(this IServiceCollection collection){
        
        collection.AddScoped<IAuthenticationService, AuthenticationService>();
        collection.AddScoped<IProductService, ProductService>();
        collection.AddScoped<IRolePermissionService, RolePermissionService>();
        collection.AddScoped<IRoleService, RoleService>();

        return collection;
    }
}