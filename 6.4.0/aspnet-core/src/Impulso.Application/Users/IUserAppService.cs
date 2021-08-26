using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Impulso.Roles.Dto;
using Impulso.Users.Dto;

namespace Impulso.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<UserDto> GetUserByIdDto(int id);
        Task DeActivate(EntityDto<long> user);
        Task Activate(EntityDto<long> user);
        Task<ListResultDto<RoleDto>> GetRoles();
        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
