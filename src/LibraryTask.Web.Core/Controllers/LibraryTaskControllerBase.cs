using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LibraryTask.Controllers
{
    public abstract class LibraryTaskControllerBase: AbpController
    {
        protected LibraryTaskControllerBase()
        {
            LocalizationSourceName = LibraryTaskConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
