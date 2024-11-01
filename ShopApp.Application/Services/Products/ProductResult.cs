using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.Products;

public record ProductResult(
    List<Product> Product
    );