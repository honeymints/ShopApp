using ShopApp.Domain.Entities;

namespace ShopApp.Application.DTOs.Category;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public Rating? Rating { get; set; }
    
}
