using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Services;
using ShopApp.Application.Services.Authentication;
using ShopApp.Application.Services.PermissionActions;
using ShopApp.Application.Services.Products;
using ShopApp.Application.Services.UserRoles;
using ShopApp.Infrastructure.Handlers;

namespace ShopApp.Application;

public static class DependencyInjection {

    public static IServiceCollection AddApplication(this IServiceCollection collection){
        
        collection.AddScoped<IAuthenticationService, AuthenticationService>();
        collection.AddScoped<IProductService, ProductService>();
        collection.AddScoped<IRolePermissionService, RolePermissionService>();
        collection.AddScoped<IRoleService, RoleService>();
        collection.AddScoped<IPermissionActionService, PermissionActionService>();
        collection.AddScoped<IUserRoleService, UserRoleService>();
        
        return collection;
    }
}