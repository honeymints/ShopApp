using ShopApp.Application.DTOs.Product;

namespace ShopApp.Application.Services.Products;

public record ProductResult(
    List<ProductDto> Product
    );