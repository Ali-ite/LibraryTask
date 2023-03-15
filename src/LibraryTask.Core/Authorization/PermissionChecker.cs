using Abp.Authorization;
using LibraryTask.Authorization.Roles;
using LibraryTask.Authorization.Users;

namespace LibraryTask.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
