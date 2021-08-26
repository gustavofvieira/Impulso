using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Impulso.EntityFrameworkCore;
using Impulso.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Impulso.Web.Tests
{
    [DependsOn(
        typeof(ImpulsoWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ImpulsoWebTestModule : AbpModule
    {
        public ImpulsoWebTestModule(ImpulsoEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImpulsoWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ImpulsoWebMvcModule).Assembly);
        }
    }
}