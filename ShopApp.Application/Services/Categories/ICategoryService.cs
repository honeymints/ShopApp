using ShopApp.Application.DTOs.Category;
using ShopApp.Application.DTOs.Role;

namespace ShopApp.Application.Services.Category;



public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategories();

    Task<CategoryDto> GetCategoryById(Guid categoryId);

    // Task<List<RoleDto>> GetRolesByUserId(Guid userId);

    Task CreateCategory(string Name, string Description);
    Task UpdateCategory(CategoryDto categoryDtoDto);

    Task DeleteCategory(Guid id);

   // Task CheckIfExists(string name);

    Task CheckIfExists(Guid id);

}