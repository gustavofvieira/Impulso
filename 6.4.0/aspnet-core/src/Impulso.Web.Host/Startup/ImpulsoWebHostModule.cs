using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Impulso.Configuration;

namespace Impulso.Web.Host.Startup
{
    [DependsOn(
       typeof(ImpulsoWebCoreModule))]
    public class ImpulsoWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ImpulsoWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ImpulsoWebHostModule).GetAssembly());
        }
    }
}
