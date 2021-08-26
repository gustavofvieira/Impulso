using System.Threading.Tasks;
using Abp.Application.Services;
using Impulso.Sessions.Dto;

namespace Impulso.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
