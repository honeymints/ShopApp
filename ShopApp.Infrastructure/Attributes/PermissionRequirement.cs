using Microsoft.AspNetCore.Authorization;

namespace ShopApp.Infrastructure.Attributes;


public class PermissionRequirement : IAuthorizationRequirement
{
    public string Permission { get; }
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}