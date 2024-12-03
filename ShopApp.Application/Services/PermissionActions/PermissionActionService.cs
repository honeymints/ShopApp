using Mapster;
using MapsterMapper;
using ShopApp.Application.DTOs.RolePermissions;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;
using ShopApp.Domain.Enums;

namespace ShopApp.Application.Services.PermissionActions;



public class PermissionActionService : IPermissionActionService
{
    private readonly IMapper _mapper;
    private readonly IPermissionActionRepository _permissionActionRepository;

    private readonly IPermissionCategoryRepository _permissionCategoryRepository;
    public PermissionActionService(IPermissionActionRepository permissionActionRepository,
        IPermissionCategoryRepository permissionCategoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _permissionCategoryRepository = permissionCategoryRepository;
        _permissionActionRepository = permissionActionRepository;
    }

    public async Task<List<PermissionActionDto>> GetAllPermissionActions()
    {
        var permissionActions = await _permissionActionRepository.GetAll();
        // var permissionActionDtos = permissionActions.Select(x => new PermissionActionDto
        // {
        //     Id = x.Id,
        //     Value = x.Value,
        //     Name = x.Name,
        //     Description = x.Description
        // }).ToList();

        var permissionActionDtos = permissionActions
        .Select((x) => _mapper.Map<PermissionActionDto>(x))
        .ToList();

        return permissionActionDtos;
    }

    public async Task<PermissionActionDto> GetPermissionAction(Guid id)
    {
        await CheckIfExists(id);

        var permissionAction = await _permissionActionRepository.FindById(id);

        var permissionActionDto = _mapper.Map<PermissionActionDto>(permissionAction);

        return permissionActionDto;
    }

    public async Task InsertPermissionAction(
        string name,
        string description,
        int value,
        Guid categoryId)
    {
        var permissions = await _permissionActionRepository.GetAll();

        if (value == 0) throw new Exception("value cannot be 0!");

        if (!await _permissionCategoryRepository.IsExists(categoryId))
        {
            throw new KeyNotFoundException("category id is invalid or such category doesn't exist!");
        }

        if (permissions.Any(x => x.Value == (PermissionActionEnum)value))
        {
            throw new Exception("there is already permission with such value");
        }


        var permissionAction = new PermissionAction
        {
            PermissionCategoryId = categoryId,
            Name = name,
            Description = description,
            Value = (PermissionActionEnum)value
        };

        await _permissionActionRepository.InsertAsync(permissionAction);
        await _permissionActionRepository.SaveAsync();

    }

    public async Task UpdatePermissionAction(PermissionActionDto permissionActionDto)
    {
        await _permissionActionRepository.SaveAsync();
    }

    public async Task DeletePermissionAction(Guid id)
    {
        await CheckIfExists(id);
        await _permissionActionRepository.DeleteAsync(id);
        await _permissionActionRepository.SaveAsync();

    }

    public async Task CheckIfExists(Guid id)
    {
        if (!await _permissionActionRepository.IsExists(id))
        {
            throw new KeyNotFoundException("such permission doesn't exist!");
        }
    }
}