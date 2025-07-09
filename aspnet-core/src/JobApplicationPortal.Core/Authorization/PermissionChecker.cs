using Abp.Authorization;
using JobApplicationPortal.Authorization.Roles;
using JobApplicationPortal.Authorization.Users;

namespace JobApplicationPortal.Authorization;

public class PermissionChecker : PermissionChecker<Role, User>
{
    public PermissionChecker(UserManager userManager)
        : base(userManager)
    {
    }
}
