using ShopApp.Application.DTOs.PermissionCategory;

namespace ShopApp.Application.Services.PermissionCategories;


public interface IPermissionCategoryService
{
    Task<PermissionCategoryDto> GetById(Guid id);

    Task<IReadOnlyCollection<PermissionCategoryDto>> GetAll();

    Task CreatePermissionCategory(
        string name,
        string? description,
        int value);
    Task UpdatePermissionCategory(
        Guid id,
        string name,
        string? description,
        int value);
    Task DeletePermissionCategory(Guid id);

    Task CheckIfExists(Guid id);

}