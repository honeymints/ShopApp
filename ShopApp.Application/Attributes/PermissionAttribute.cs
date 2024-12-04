
using Microsoft.AspNetCore.Authorization;
using ShopApp.Domain.Enums;

namespace ShopApp.Application.Attributes;


public class PermissionAttribute : AuthorizeAttribute
{
    public PermissionAttribute(PermissionActionEnum permissionAction)
    {
        Policy = permissionAction.ToString();
    }

}