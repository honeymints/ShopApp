namespace ShopApp.Contracts.Category;


public record CreateCategoryRequest(
    string Name,
    string? Description
);