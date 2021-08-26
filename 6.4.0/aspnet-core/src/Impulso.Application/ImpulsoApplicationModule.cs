using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Impulso.Authorization;

namespace Impulso
{
    [DependsOn(
        typeof(ImpulsoCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ImpulsoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ImpulsoAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ImpulsoApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
