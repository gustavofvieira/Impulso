using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Impulso.Controllers
{
    public abstract class ImpulsoControllerBase: AbpController
    {
        protected ImpulsoControllerBase()
        {
            LocalizationSourceName = ImpulsoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
