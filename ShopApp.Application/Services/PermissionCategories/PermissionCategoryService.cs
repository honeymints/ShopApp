using MapsterMapper;
using ShopApp.Application.DTOs.PermissionCategory;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Domain.Enums;

namespace ShopApp.Application.Services.PermissionCategories;



public class PermissionCategoryService : IPermissionCategoryService
{
    private readonly IPermissionCategoryRepository _permissionCategoryRepository;

    private readonly IMapper _mapper;

    public PermissionCategoryService(IPermissionCategoryRepository permissionCategoryRepository, IMapper mapper)
    {
        _permissionCategoryRepository = permissionCategoryRepository;
        _mapper = mapper;
    }

    public async Task CheckIfExists(Guid id)
    {
        if (!await _permissionCategoryRepository.IsExists(id))
            throw new Exception("such permission category doesn't exist!");
    }

    public async Task CreatePermissionCategory(string name, string? description, int value)
    {
        var permissionCategory = new PermissionCategory
        {
            Name = name,
            Description = description,
            Value = (PermissionCategoryEnum)value
        };

        await _permissionCategoryRepository.InsertAsync(permissionCategory);
        await _permissionCategoryRepository.SaveAsync();
    }

    public async Task DeletePermissionCategory(Guid id)
    {
        await CheckIfExists(id);

        await _permissionCategoryRepository.DeleteAsync(id);
        await _permissionCategoryRepository.SaveAsync();
    }

    public async Task<IReadOnlyCollection<PermissionCategoryDto>> GetAll()
    {
        var permissionCategories = await _permissionCategoryRepository.GetAll();

        var permissionCategoryDtos = permissionCategories.AsEnumerable()
                                                         .Select(x => _mapper.Map<PermissionCategoryDto>(x))
                                                         .ToList();
        return permissionCategoryDtos;
    }

    public async Task<PermissionCategoryDto> GetById(Guid id)
    {
        await CheckIfExists(id);

        var permissionCategory = await _permissionCategoryRepository.Get(id);

        var permissionCategoryDto = _mapper.Map<PermissionCategoryDto>(permissionCategory);

        return permissionCategoryDto;
    }

    public async Task UpdatePermissionCategory(Guid id, string name, string? description, int value)
    {
        await CheckIfExists(id);
        var permissionCategory = await _permissionCategoryRepository.Get(id);

        permissionCategory.Name = name;
        permissionCategory.Description = description;
        permissionCategory.Value = (PermissionCategoryEnum)value;

        await _permissionCategoryRepository.UpdateAsync(permissionCategory);
        await _permissionCategoryRepository.SaveAsync();
    }
}