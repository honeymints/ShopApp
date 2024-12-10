using ShopApp.Application.DTOs.Category;
using ShopApp.Application.Persistence;
using ShopApp.Application.Services.Category;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Categories;


public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task CheckIfExists(Guid id)
    {
        if (!await _categoryRepository.IsExists(id))
        {
            throw new Exception("Such category doesn't exist");
        }
    }

    public async Task CreateCategory(string name, string description)
    {
        if (await _categoryRepository.IsExists(name))
        {
            throw new Exception("such category already exists!");
        }

        var category = new Category
        {
            Name = name.ToUpper(),
            Description = description
        };

        await _categoryRepository.InsertAsync(category);
        await _categoryRepository.SaveAsync();
    }

    public async Task DeleteCategory(Guid id)
    {
        await CheckIfExists(id);
        await _categoryRepository.DeleteAsync(id);
        await _categoryRepository.SaveAsync();
    }

    public async Task<List<CategoryDto>> GetAllCategories()
    {
        var categories = await _categoryRepository.GetAll();
        var categoryDtos = categories
            .AsEnumerable()
            .Select(x => new CategoryDto
            {
                Id =x.Id,
                Name = x.Name,
                Description = x.Description,
            })
            .ToList();

        return categoryDtos;
    }

    public async Task<CategoryDto> GetCategoryById(Guid categoryId)
    {
        await CheckIfExists(categoryId);
        var category = await _categoryRepository.Get(categoryId);

        var categoryDto = new CategoryDto
        {
            Name = category.Name,
            Description = category.Description
        };
        return categoryDto;
    }

    public async Task UpdateCategory(CategoryDto categoryDtoDto)
    {
        throw new NotImplementedException();
    }
}
