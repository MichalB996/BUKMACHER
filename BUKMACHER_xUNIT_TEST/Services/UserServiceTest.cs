using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using NUnit;
using Moq;
using BUKMACHER_CORE.Repositories;
using BUKMACHER_INFRASTRUCTURE.Services;
using AutoMapper;
using BUKMACHER_CORE.Domain;
using BUKMACHER_INFRASTRUCTURE.DTO;

namespace BUKMACHERT_TESTS.Services
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
