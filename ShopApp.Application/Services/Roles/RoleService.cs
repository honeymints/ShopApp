using ShopApp.Application.DTOs.Role;
using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services;


public class RoleService : IRoleService
{

    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
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

    public async Task DeleteRole(Guid RoleId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RoleDto>> GetAllRoles()
    {
        var listOfRole = await _roleRepository.GetAll();

        return listOfRole.Select(x => new RoleDto
        {
            Id = x.Id,
            Description =x.Description,
            Name = x.Name,
        }).ToList();
        
    }

    public async Task<RoleDto> GetRoleById(Guid roleId)
    {
        throw new NotImplementedException();
    }

    public async Task<List<RoleDto>> GetRolesByUserId(Guid userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateRole(RoleDto roleDto)
    {
        throw new NotImplementedException();
    }
}