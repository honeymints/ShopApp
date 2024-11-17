using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using ShopApp.Domain.Entities;
using ShopApp.Domain.Enums;
using ShopApp.Infrastructure.Attributes;

namespace ShopApp.Infrastructure.Handlers;



public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {

        var user = context.User;

        if (user == null || user.Identity.IsAuthenticated)
        {
            context.Fail();

            return Task.CompletedTask;
        }

        bool isAuthorized = CheckUserPermission(user, (PermissionActionEnum)Enum.Parse(typeof(PermissionActionEnum), requirement.Permission));
    }

    private bool CheckUserPermission(ClaimsPrincipal user, PermissionActionEnum permissionActionEnum)
    {
        // check if user has permission
        var userPermission = user.FindFirst("Permssions")?.Value;

        if (string.IsNullOrEmpty(userPermission))
        {
            return false;
        }

        var permissions = JsonConvert.DeserializeObject<PermissionsClaim>(userPermission);
        //
        return HasRequiredPermissions(permissionActionEnum, permissions);


    }

    private bool HasRequiredPermissions(PermissionActionEnum permissionActionEnum, PermissionsClaim? permissions)
    {
        foreach (var cateogry in permissions.PermissionCategories)
        {
                if(cateogry.PermissionActions.Any(x=>x.Value == permissionActionEnum)){
                    return true;
                }
        }

        return false;
    }
}