using System.Threading.Tasks;
using Impulso.Configuration.Dto;

namespace Impulso.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
