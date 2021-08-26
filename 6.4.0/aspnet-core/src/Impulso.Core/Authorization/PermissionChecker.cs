using Abp.Authorization;
using Impulso.Authorization.Roles;
using Impulso.Authorization.Users;

namespace Impulso.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
