using Microsoft.AspNetCore.Authorization;
using ShopApp.Domain.Enums;

namespace ShopApp.Api.Attributes;


public class PermissionAttribute : AuthorizeAttribute
{

    public PermissionAttribute(PermissionActionEnum permissionAction)
    {
        Policy = permissionAction.ToString();
    }

}