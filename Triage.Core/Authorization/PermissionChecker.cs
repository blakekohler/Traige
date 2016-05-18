using Abp.Authorization;
using Triage.Authorization.Roles;
using Triage.MultiTenancy;
using Triage.Users;

namespace Triage.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
