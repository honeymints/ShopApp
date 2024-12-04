using ShopApp.Application.Persistence;
using ShopApp.Domain.Entities;

namespace ShopApp.Application.Services.UserRoles;


public class UserRoleService : IUserRoleService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleRepository;

    private readonly IRoleRepository _roleRepository;
    public UserRoleService(IUserRoleRepository userRoleRepository,
    IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task AssignRolesToUser(Guid userId, Guid[] roleIds)
    {
        var userRoles = roleIds.Select(
          x => new UserRole
          {
              UserId = userId,
              RoleId = x
          }
          ).ToList();

        foreach (var userRole in userRoles)
        {
           await CheckIfExists(userRole);

            if (await _userRoleRepository.IsUserExistsWithSuchRoles(
                  userRole.UserId,
                  userRole.RoleId))
            {
                throw new Exception("There are already roles that assigned to such user");
            }
        }

        await _userRoleRepository.InsertRangeAsync(userRoles);
        await _userRoleRepository.SaveAsync();

    }

    public async Task CheckIfExists(UserRole userRole)
    {
        if (!await _userRepository.IsExists(userRole.UserId) &&
            !await _roleRepository.IsExists(userRole.RoleId))
        {
            throw new Exception("Such user or role doesn't exist");
        }
    }

    public async Task UnAssignRolesFromUser(Guid userId, Guid[] roleIds)
    {
        var userRoles = roleIds.Select(
          x => new UserRole
          {
              UserId = userId,
              RoleId = x
          }
          ).ToList();

        foreach (var userRole in userRoles)
        {
            await CheckIfExists(userRole);

            if (!await _userRoleRepository.IsUserExistsWithSuchRoles(
                 userRole.UserId,
                 userRole.RoleId))
            {
                throw new Exception("There are no such roles that assigned to such user");
            }
            await _userRoleRepository.DeleteAsync(userRole.Id);
        }

        await _userRoleRepository.SaveAsync();
    }


}