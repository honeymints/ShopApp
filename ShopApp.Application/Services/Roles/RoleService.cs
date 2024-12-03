using MapsterMapper;
using ShopApp.Application.DTOs.Role;
using ShopApp.Application.DTOs.RolePermissions;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services;


public class RoleService : IRoleService
{

    private readonly IMapper _mapper;
    private readonly IRoleRepository _roleRepository;
    private readonly IRolePermissionRepository _rolePermissionRepository;



    public RoleService(IRoleRepository roleRepository,
     IMapper mapper, IRolePermissionRepository rolePermissionRepository)
    {
        _roleRepository = roleRepository;
        _rolePermissionRepository = rolePermissionRepository;

        _mapper = mapper;
    }

    public async Task CreateRole(CreateRoleDto roleDto)
    {
        if (await _roleRepository.IsExists(roleDto.Name))
        {
            throw new Exception("Such role already exists!");
        }

        var role = new Role
        {
            Name = roleDto.Name,
            Description = roleDto.Description,
        };

        await _roleRepository.InsertAsync(role);
        await _roleRepository.SaveAsync();
    }

    public async Task DeleteRole(Guid roleId)
    {
        if (!await _roleRepository.IsExists(roleId))
        {
            throw new KeyNotFoundException("Such role doesn't exist!");
        }

        await _roleRepository.DeleteAsync(roleId);
    }

    public async Task<List<RoleDto>> GetAllRoles()
    {
        var listOfRole = await _roleRepository.GetAll();

        return listOfRole.Select(x => new RoleDto
        {
            Id = x.Id,
            Description = x.Description,
            Name = x.Name,
            PermissionActions = x.RolePermissions
            .Where(r => r.RoleId == x.Id)
            .Select(y => new PermissionActionDto
            {
                Id = y.PermissionAction.Id,
                Value = y.PermissionAction.Value,
                Name = y.PermissionAction.Name,
                Description = y.PermissionAction.Description
            }).ToList(),
        }).ToList();

    }

    public async Task<RoleDto> GetRoleById(Guid roleId)
    {
        var role = await _roleRepository.FindById(roleId);

        if (role is null)
        {
            throw new KeyNotFoundException("Role was not found!");
        }

        var roleDto = _mapper.Map<RoleDto>(role);

        return roleDto;
    }

    public async Task<bool> IsExists(Guid id)
    {
        return await _rolePermissionRepository.IsExists(id);
    }

    public async Task UpdateRole(RoleDto roleDto)
    {

    }
}