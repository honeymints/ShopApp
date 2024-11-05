using Mapster;
using ShopApp.Application.DTOs.Product;
using ShopApp.Application.DTOs.User;
using ShopApp.Domain.Entities;

namespace ShopApp.Infrastructure.Services;

public class MapsterConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<User, UserDto>.NewConfig()
        .RequireDestinationMemberSource(true)
        .Map(dest=> dest.Id, source=> source.Id)
        .Map(dest=> dest.Email, source=> source.Email)
        .Map(dest=> dest.Name, source=> source.Name)
        .Map(dest=> dest.LastName, source=> source.LastName);

        TypeAdapterConfig<Product, ProductDto>.NewConfig()
        .Map(dest=> dest.Id, source=> source.Id)
        .Map(dest=> dest.Description, source=> source.Description)
        .Map(dest=> dest.Name, source=> source.Name)
        .Map(dest=> dest.Price, source=> source.Price);
    }
}