using AutoMapper;
using Moq;
using SportsBetting.Core.Domain;
using SportsBetting.Core.Repositories;
using SportsBetting.Infrastructure.Services;
using System.Threading.Tasks;
using Xunit;

namespace SportsBetting.Test.EndtoEnd.Services
{
    public class UserServiceTest
    {
        [Fact]
        public async Task Register_Async_should_invokes_once()
        {
            var UserRepositoryMock = new Mock<IUserRepository>();
            var AutoMapperMock = new Mock<IMapper>();
            var userService = new UserService(UserRepositoryMock.Object,AutoMapperMock.Object);
            await userService.RegisterAsync("dupa@gmai.com", "secret", "userdupa");
            UserRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
        [Fact]
        public async Task GetAsync_should_invokes_exactly_twice()
        {
            var userRepositoryMock = new Mock<IUserRepository>();
            var mapperRepositoryMock = new Mock<IMapper>();
            var userService = new UserService(userRepositoryMock.Object, mapperRepositoryMock.Object);
            await userService.RegisterAsync("user69@gmail.com", "password", "normalmiddleschooluser");
            await userService.GetAsync("user69@gmail.com");
            userRepositoryMock.Verify( x => x.GetAsync("user69@gmail.com"), Times.Exactly(2));
        }
    }
}
