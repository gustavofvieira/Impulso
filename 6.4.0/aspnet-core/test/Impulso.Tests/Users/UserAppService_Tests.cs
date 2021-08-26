using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using Impulso.Users;
using Impulso.Users.Dto;

namespace Impulso.Tests.Users
{
    public class UserAppService_Tests : ImpulsoTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAllAsync(new PagedUserResultRequestDto{MaxResultCount=20, SkipCount=0} );

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task UpdateUser_Test()
        {
            // Arrange
            var userDto = await _userAppService.GetUserByIdDto(3);

            if (userDto is null) CreateUser_Test();
           
            //Act

            await _userAppService.UpdateAsync(
               new UserDto
               {
                   Id = 3,
                   EmailAddress = "joao.natal@volosoft.com",
                   IsActive = true,
                   Name = "João",
                   Surname = "Natal",
                   UserName = "joao.natal"
               });


            userDto = await _userAppService.GetUserByIdDto(3);
            // Assert
            Assert.Equal(userDto.Id,3);
            Assert.Equal(userDto.EmailAddress, "joao.natal@volosoft.com");
            Assert.Equal(userDto.UserName, "joao.natal");
        }
    }
}
