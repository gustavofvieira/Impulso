using Abp.Application.Services;
using Impulso.MultiTenancy.Dto;

namespace Impulso.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

