using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using ShopApp.Application.Attributes;

namespace ShopApp.Application.AuthUtils;

public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options) { }

    public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
         var requirement = new PermissionRequirement(policyName);

            // Now we use the builder to create a policy, adding our requirement
            return new AuthorizationPolicyBuilder()
                .AddRequirements(requirement)
                .Build();
    }


}
