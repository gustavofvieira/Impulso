using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Impulso.Configuration.Dto;

namespace Impulso.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ImpulsoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
