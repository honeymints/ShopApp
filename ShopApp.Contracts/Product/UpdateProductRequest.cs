namespace ShopApp.Contracts.Product;


public record UpdateProductRequest(
    string Name,
    string Description,
    decimal Price,
    Guid[]? ProductCategoryIds
);