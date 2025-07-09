using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace JobApplicationPortal.Controllers
{
    public abstract class JobApplicationPortalControllerBase : AbpController
    {
        protected JobApplicationPortalControllerBase()
        {
            LocalizationSourceName = JobApplicationPortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
