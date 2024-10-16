using Microsoft.Extensions.DependencyInjection;
using ShopApp.Application.Services.Authentication;

namespace ShopApp.Application;

public static class DependencyInjection {

    public static IServiceCollection AddApplication(this IServiceCollection collection){

        collection.AddScoped<IAuthenticationService, AuthenticationService>();

        return collection;
    }
}