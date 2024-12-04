namespace ShopApp.Contracts.Product;


public record UpdateProductRequest(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int[]? ProductCategoryIds
);