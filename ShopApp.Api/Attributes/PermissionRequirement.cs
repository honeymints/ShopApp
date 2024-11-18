using Microsoft.AspNetCore.Authorization;

namespace ShopApp.Api.Attributes;


public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}